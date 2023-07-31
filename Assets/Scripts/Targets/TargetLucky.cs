using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLucky : Target
{
    private bool isAutoDestroy;

    private void Start() {
        isAutoDestroy = false;
        StartCoroutine(AutoDestroy());
    }


    private void OnDestroy() {
        if(!isAutoDestroy)
            TargetController.Instance.SetLuckyChance();
        else 
            TargetController.Instance.AdjustPlayerKills();
    }

    IEnumerator AutoDestroy(){
        yield return new WaitForSecondsRealtime(3f);
        isAutoDestroy = true;
        base.TakeDamage();
    }
}
