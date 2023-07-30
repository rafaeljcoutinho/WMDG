using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetClock : Target
{
    private TimeManager timeManager;
    private bool isAutoDestroy;

    private void Start() {
        timeManager = GameObject.Find("TimeManager").GetComponent<TimeManager>();
        isAutoDestroy = false;
        StartCoroutine(AutoDestroy());
    }


    private void OnDestroy() {
        if(isAutoDestroy == false)
            timeManager.AddTime(15);
    }

    IEnumerator AutoDestroy(){
        yield return new WaitForSecondsRealtime(3f);
        isAutoDestroy = true;
        base.TakeDamage();
    }


}
