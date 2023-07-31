using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ammoUI;
    [SerializeField] private int ammoCapacity;
    [SerializeField] private float timeToShoot;
    [SerializeField] private float timeToCocked;
    [SerializeField] private float timeToReload;
    [SerializeField] private Animator weaponAnimator;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField, Range(0,1)] private float recoilY;
    [SerializeField, Range(0,1)] private float recoilX;  
    [SerializeField, Range(1,5)] private float recoilResetTime;
    [SerializeField] private float limitRecoilMultiplayer;
    [SerializeField] private float recoilMultiplier = 1f;
    [SerializeField] private AudioSource shotAudio; 
    [SerializeField] private AudioSource reloadAudio1;
    [SerializeField] private AudioSource reloadAudio2;
    [SerializeField] private AudioSource reloadAudio3;
    [SerializeField] private AudioSource cockedAudio;
    
    private bool isUnlimitedAmmo;
    private int currentAmmo;
    private float lastShotTime;
    private Vector2 currentRecoil;
    private bool isReloading = false;
    private float nextFire;

    public ParticleSystem muzzleFlash;
    public Vector2 CurrentRecoil => currentRecoil;
    public int CurrentAmmo => currentAmmo;
    public int AmmoCapaicty => ammoCapacity;
    

    void Awake()
    {
        isUnlimitedAmmo = false;
        currentAmmo = ammoCapacity;
        UpdateUI();
    }

    void Update()
    {
        if(recoilMultiplier > limitRecoilMultiplayer)
        {
            recoilMultiplier = limitRecoilMultiplayer;
        }
        if (Time.time > lastShotTime + recoilResetTime)  
        {
            recoilMultiplier = 1;
        }
    }
    
    public void Shoot(Transform firePoint)
    {
        if(Time.unscaledTime > nextFire){
           
            if (currentAmmo > 0 && !isReloading )
            { 
                nextFire = Time.unscaledTime + timeToShoot;
                TargetController.Instance.PlayerShoot();
                weaponAnimator.SetTrigger("Fire");
                shotAudio.Play();
                muzzleFlash.Play();
                Instantiate(bulletPrefab, firePoint.position + transform.forward, firePoint.rotation);
                if(!isUnlimitedAmmo){
                    currentAmmo--;
                    UpdateUI();
                }
                lastShotTime = Time.unscaledTime; 
                recoilMultiplier += 0.1f;  
                StartCoroutine(ApplyRecoil());
                
            }else if(currentAmmo == 0 && !isReloading){
                cockedAudio.Play();
                nextFire = Time.unscaledTime + timeToCocked;
            }
        }
       
    }


    private IEnumerator ApplyRecoil()
    {
        Vector2 recoilAmount = new Vector2(-recoilY * recoilMultiplier * Random.Range(0.2f, 1f), recoilX * recoilMultiplier * Random.Range(-0.2f, 0.2f));
        float recoilOverTime = 0.1f;
        float recoveryTime = 0.1f;
        float elapsedTime = 0f;
       
        while (elapsedTime < recoilOverTime)
        {
            currentRecoil = Vector2.Lerp(Vector2.zero, recoilAmount, elapsedTime / recoilOverTime);
            elapsedTime += Time.unscaledDeltaTime ;

            yield return null;
        }
       
        currentRecoil = recoilAmount;
        elapsedTime = 0f;
      
        while (elapsedTime < recoveryTime)
        {
            currentRecoil = Vector2.Lerp(recoilAmount, Vector2.zero, elapsedTime / recoveryTime);
            elapsedTime += Time.unscaledDeltaTime;

            yield return null;
        }
        
        currentRecoil = Vector2.zero;
    }

    public void UnilimtedAmmoTime(float t){
        StartCoroutine(UnlimitedAmmo(t));
    }

    private IEnumerator UnlimitedAmmo(float t){
        isUnlimitedAmmo = true;
        currentAmmo = ammoCapacity;
        ammoUI.text = "**/**";
        yield return new WaitForSecondsRealtime(t);
        isUnlimitedAmmo = false;

    }


    public void Reload()
    {
        if(!isReloading)
        {
            isReloading = true;
            //playReloadingAnimation
            weaponAnimator.SetTrigger("Reload");
            ammoUI.text = "Reloading...";
            StartCoroutine(WaitToReload());
        }
    }

    IEnumerator WaitToReload()
    {
        reloadAudio1.Play();
        yield return new WaitForSecondsRealtime(timeToReload/2);
        reloadAudio2.Play();
        yield return new WaitForSecondsRealtime(timeToReload/4);
        reloadAudio3.Play();
        yield return new WaitForSecondsRealtime(timeToReload/4);
        currentAmmo = ammoCapacity;
        UpdateUI();
        isReloading = false;
        yield return null;
    }

    private void UpdateUI()
    {
        ammoUI.text = currentAmmo + "/" + ammoCapacity;
    }

}
