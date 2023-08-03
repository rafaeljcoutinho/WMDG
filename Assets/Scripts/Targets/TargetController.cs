using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class TargetController : MonoBehaviour
{
    public static TargetController Instance;
    [SerializeField] private TargetNormal targetNormalPrefab;
    [SerializeField] private TargetClock targetClockPrefab;
    [SerializeField] private Target2xPoints target2xPointsPrefab;
    [SerializeField] private TargetTurttle targetTurttlePrefab;
    [SerializeField] private TargetBombIt targetBombItPrefab;
    [SerializeField] private Target8Ammo target8AmmoPrefab;
    [SerializeField] private TargetLucky targetLuckyPrefab;
    [SerializeField] private List<BoxCollider> SpawnAreas;
    [SerializeField] private float minTimerToSpawn;
    [SerializeField] private float maxTimerToSpawn;
    [SerializeField] private float scaleChangeSpeed;
    [SerializeField] private TextMeshProUGUI levelTextUI;
    [SerializeField] private TextMeshProUGUI x2TextUI;
    [SerializeField] public TextMeshProUGUI TimeTextUI;
    [SerializeField] public Image TurtleImageUI;
    [SerializeField] public Image LuckyTextUI;

    [SerializeField] private TextMeshProUGUI LuckyChance;

    private float specialTargetChance;
    private WeaponManager weaponManager;
    private Vector3 currentScale; 
    private int playerShoots;
    private int playerKills;
    private float speed;
    private float value;
    private float valueMultiplier;

    private int bonusTime;
    private Vector3 targetSize;
    private List<GameObject> targetList = new List<GameObject>();

    public float Value => value * valueMultiplier;
    public Vector3 CurrentScale => currentScale;



    void Awake(){
        specialTargetChance = 15f;
        if (GameObject.Find("Ak")) {
            weaponManager = GameObject.Find("Ak").GetComponent<WeaponManager>();
        } else if (GameObject.Find("Deagle")) {
            weaponManager = GameObject.Find("Deagle").GetComponent<WeaponManager>();
        }
        scaleChangeSpeed = 4.0f;
        targetSize = new Vector3(1,1,1);
        minTimerToSpawn = 0f;
        maxTimerToSpawn = 4f;
        speed = 1;
        playerKills = 6;
        playerShoots = 10;
        value = 10;
        valueMultiplier = 1;
        if(Instance == null){
            Instance = this;
        }else
            Destroy(gameObject);
        
        foreach(BoxCollider b in SpawnAreas){
            Vector3 minBounds = b.bounds.min;
            Vector3 maxBounds = b.bounds.max;

            Vector3 randomInitPosition = new Vector3(
                Random.Range(minBounds.x, maxBounds.x),
                Random.Range(minBounds.y, maxBounds.y),
                Random.Range(minBounds.z, maxBounds.z)
            );
            Vector3 randomFinalPosition = new Vector3(
                Random.Range(minBounds.x, maxBounds.x),
                Random.Range(minBounds.y, maxBounds.y),
                Random.Range(minBounds.z, maxBounds.z)
            );
            Target newTarget = Instantiate(targetNormalPrefab);
            newTarget.SetupTarget(randomInitPosition, randomFinalPosition, targetSize, true, speed, b.bounds);
            AddItem(newTarget.gameObject);
        }
    }
    public void AddItem(GameObject item)
    {
        targetList.Add(item);
    }

    // Método para remover um item da lista
    public void RemoveItem(GameObject item)
    {
        targetList.Remove(item);
    }

    public void AdjustPlayerKills(){
        playerKills--;
    }

    public void RespawnTargetInBounds(Bounds bounds)
    {
        // Aguarde o tempo de respawn antes de instanciar um novo alvo
        float time = Random.Range(minTimerToSpawn, maxTimerToSpawn);
        StartCoroutine(RespawnCoroutine(bounds, time));
    }

    private IEnumerator RespawnCoroutine(Bounds bounds, float respawnTime)
    {
        playerKills++;
        yield return new WaitForSeconds(respawnTime);

        Vector3 minBounds = bounds.min;
        Vector3 maxBounds = bounds.max;

        Vector3 randomInitPosition = new Vector3(
            Random.Range(minBounds.x, maxBounds.x),
            Random.Range(minBounds.y, maxBounds.y),
            Random.Range(minBounds.z, maxBounds.z)
        );
        Vector3 randomFinalPosition = new Vector3(
            Random.Range(minBounds.x, maxBounds.x),
            Random.Range(minBounds.y, maxBounds.y),
            Random.Range(minBounds.z, maxBounds.z)
        );
        float selectTarget = Random.Range(0f,100f);
        if(selectTarget <= specialTargetChance){
            selectTarget = Random.Range(5f,95f);

            if(selectTarget < 10f){
                TargetClock newTargetClock = Instantiate(targetClockPrefab);
                newTargetClock.SetupTarget(randomInitPosition, randomFinalPosition, targetSize, true, speed, bounds);
                AddItem(newTargetClock.gameObject);
            }
            else if(selectTarget >= 10f && selectTarget < 30f){
                Target2xPoints newTarget2xPoints = Instantiate(target2xPointsPrefab);
                newTarget2xPoints.SetupTarget(randomInitPosition, randomFinalPosition, targetSize, true, speed, bounds);
                AddItem(newTarget2xPoints.gameObject);
            }
            else if(selectTarget >= 30f && selectTarget < 50f){
                TargetTurttle newTargetTurttle = Instantiate(targetTurttlePrefab);
                newTargetTurttle.SetupTarget(randomInitPosition, randomFinalPosition, targetSize, true, speed, bounds);
                AddItem(newTargetTurttle.gameObject);
            }
            else if(selectTarget >= 50f && selectTarget < 70f){
                TargetBombIt newTargetBombIt = Instantiate(targetBombItPrefab);
                newTargetBombIt.SetupTarget(randomInitPosition, randomFinalPosition, targetSize, true, speed, bounds);
                AddItem(newTargetBombIt.gameObject);
            }
            else if(selectTarget >= 70f && selectTarget < 90f){
                Target8Ammo newTarget8Ammo = Instantiate(target8AmmoPrefab);
                newTarget8Ammo.SetupTarget(randomInitPosition, randomFinalPosition, targetSize, true, speed, bounds);
                AddItem(newTarget8Ammo.gameObject);
            }
            else if(selectTarget >= 90f && selectTarget < 100f){
                TargetLucky newTargetLucky = Instantiate(targetLuckyPrefab);
                newTargetLucky.SetupTarget(randomInitPosition, randomFinalPosition, targetSize, true, speed, bounds);
                AddItem(newTargetLucky.gameObject);
            }
            else{
                TargetNormal newTarget = Instantiate(targetNormalPrefab);
                newTarget.SetupTarget(randomInitPosition, randomFinalPosition, targetSize, true, speed, bounds);
                AddItem(newTarget.gameObject);
            }
        }else{
            TargetNormal newTarget = Instantiate(targetNormalPrefab);
            newTarget.SetupTarget(randomInitPosition, randomFinalPosition, targetSize, true, speed, bounds);
            AddItem(newTarget.gameObject);
        }
    }




    private void Update() {

        Debug.Log("speed: " + speed);
        Debug.Log("targetSize: " + targetSize);
        Debug.Log("luckyChance: " + specialTargetChance + "%");
        Debug.Log("valueMultiplier: " + valueMultiplier);
        //Debug.Log("hits: " + playerKills);
        //Debug.Log("shots: " + playerShoots);


        if(valueMultiplier >= 2f){
            x2TextUI.text = "x " + valueMultiplier;
            x2TextUI.gameObject.SetActive(true);
        }else{
            x2TextUI.gameObject.SetActive(false);
        }


        if(playerShoots%10 == 0)
            CalculateDificulty();



        if (currentScale != targetSize)
        {
            currentScale = Vector3.Lerp(currentScale, targetSize, Time.deltaTime * scaleChangeSpeed);
            transform.localScale = currentScale;
        }
    }

    public void PlayerShoot(){
        playerShoots++;
    }

    public void CalculateDificulty(){
        float playerStats = (float)playerKills / (float)playerShoots;
        float scale = targetSize.x;
        if(playerStats > 0.85f){
            levelTextUI.text = "Very Hard";
            speed = 5f;
            scale = 0.5f;
            value = 25;
        }
        else if(playerStats > 0.7f){
            levelTextUI.text = "Hard";
            speed = 3f;
            scale = 0.75f;
            value = 15;
        }
        else if(playerStats >= 0.6f){
            levelTextUI.text = "Normal";
            speed = 1;
            scale = 1f;
            value = 10;
        }
        else if(playerStats > 0.4f){
            levelTextUI.text = "Easy";
            speed = 0.7f;
            scale = 1.25f;
            value = 5;
        }
        else{
            levelTextUI.text = "Very Easy";
            speed = 0.3f;
            scale = 1.5f;
            value = 1;
        }
        targetSize = new Vector3(scale, scale, scale);
    }

    public void SetDoublePoints(float t){
        StartCoroutine(SetDoublePointsCoroutine(t));
    }

    private IEnumerator SetDoublePointsCoroutine(float t){
        valueMultiplier = valueMultiplier * 2;
        x2TextUI.text = "x"+valueMultiplier;
        yield return new WaitForSecondsRealtime(t);
        valueMultiplier = valueMultiplier * 1/2;
        if(valueMultiplier == 1)
            x2TextUI.gameObject.SetActive(false);
        x2TextUI.text = "x"+valueMultiplier;
        yield return null;
    }

    public void SetTimeScale(float t){
        StartCoroutine(SetTimeScaleCoroutine(t));
    }

    IEnumerator SetTimeScaleCoroutine(float t){
        TurtleImageUI.gameObject.SetActive(true);
        Time.timeScale = Time.timeScale / 2;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        yield return new WaitForSecondsRealtime(t);
        Time.timeScale = Time.timeScale * 2;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        if(Time.timeScale >= 1)
            TurtleImageUI.gameObject.SetActive(false);
    }

    public void BombIt(){
        for(int i=targetList.Count-1 ; i>=0 ; i--){
            targetList[i].GetComponent<Target>().TakeDamage();
        }
    }

    public void SetUnlimitedAmmo(){
        if(weaponManager != null)
            weaponManager.UnilimtedAmmoTime(5f);
    }

    public void SetLuckyChance(){
        specialTargetChance = specialTargetChance + 3f;
        if(specialTargetChance > 30f){
            specialTargetChance = 30f;
        }
        LuckyChance.text = ((int)specialTargetChance) + "%";
        StartCoroutine(SetLuckyChanceCoroutine(5f));
    }

    IEnumerator SetLuckyChanceCoroutine(float t){
        LuckyTextUI.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(t);
        LuckyTextUI.gameObject.SetActive(false);
    }

    IEnumerator SetAddTimeCoroutine(float t, TimeManager timeManager){
        TargetController.Instance.TimeTextUI.gameObject.SetActive(true);
        bonusTime += 15;
        TargetController.Instance.TimeTextUI.text = "+"+ bonusTime +"s";
        timeManager.AddTime(15);
        yield return new WaitForSecondsRealtime(t);
        TargetController.Instance.TimeTextUI.gameObject.SetActive(false);
        bonusTime = 0;
        yield return null;
    }

    public void SetAddTime(float t, TimeManager timeManager){
        StartCoroutine(SetAddTimeCoroutine(t, timeManager));
    }

}