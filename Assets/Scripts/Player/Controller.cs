using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private WeaponManager weaponManager;
    [SerializeField] private Transform firePoint;

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            weaponManager.Shoot(firePoint);
        }
    }

}


