using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target2xPoints : Target
{
    private bool isAutoDestroy;
    private void Start() {
        PlayerData.Instance.allSpecialTargets++;
        isAutoDestroy = false;
        StartCoroutine(AutoDestroy());
    }


    private void OnDestroy() {
        if(!isAutoDestroy){
            TargetController.Instance.SetDoublePoints(10);
        }
        else 
            TargetController.Instance.AdjustPlayerKills();
    }

    IEnumerator AutoDestroy(){
        yield return new WaitForSecondsRealtime(3f);
        isAutoDestroy = true;
        base.TakeDamage();
    }


}
