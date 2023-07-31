using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTurttle : Target
{
    private bool isAutoDestroy;

    private void Start() {
        isAutoDestroy = false;
        StartCoroutine(AutoDestroy());
    }

    private IEnumerator AutoDestroy()
    {
        yield return new WaitForSecondsRealtime(3);
        isAutoDestroy = true;
        base.TakeDamage();
    }

    private void OnDestroy() {
        if(!isAutoDestroy){
            TargetController.Instance.SetTimeScale(5);
        }
        else 
            TargetController.Instance.AdjustPlayerKills();
    }
}
