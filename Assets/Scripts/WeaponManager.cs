using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private int ammoQuantity;
    [SerializeField] private int ammoCapacity;
    [SerializeField] private float timeToShoot;
    [SerializeField] private Animator weaponAnimator;
    [SerializeField] private GameObject bulletPrefab;

    private float nextFire;

    public void Shoot(Transform firePoint)
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + timeToShoot;
            weaponAnimator.SetTrigger("Fire");
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
        
    }

}
