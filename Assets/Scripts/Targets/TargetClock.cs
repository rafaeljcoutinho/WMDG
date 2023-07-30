using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetClock : Target
{
    private TimeManager timeManager;
    private bool isAutoDestroy;


    private void OnDestroy() {
        if(isAutoDestroy == false)
            timeManager.AddTime(15);
    }


     public void SetupTarget(Vector3 initialPosition, Vector3 finalPosition, Vector3 scale, bool isMove, float speed, Bounds bounds, TimeManager timeManager)
    {
        base.SetupTarget(initialPosition, finalPosition, scale, isMove, speed, bounds);
        this.timeManager = timeManager;
        isAutoDestroy = false;
        StartCoroutine(AutoDestroy());
    }

    IEnumerator AutoDestroy(){
        yield return new WaitForSecondsRealtime(3f);
        isAutoDestroy = true;
        base.TakeDamage();
    }


}
