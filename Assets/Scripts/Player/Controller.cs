using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private WeaponManager weaponManager;
    [SerializeField] private Transform firePoint;
    [SerializeField] public bool isPaused = false;

    void Update()
    {
        if (Input.GetButton("Fire1") && !isPaused)
        {
            weaponManager.Shoot(firePoint);
        } else if (Input.GetKeyDown(KeyCode.R) && !isPaused)
        {
            weaponManager.Reload();
        }
    }

}


