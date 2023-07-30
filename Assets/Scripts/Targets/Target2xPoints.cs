using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target2xPoints : Target
{
    private TargetController targetController;
    private bool isAutoDestroy;
    private void Start() {
        targetController = GameObject.Find("SpawnTargets").GetComponent<TargetController>();
        isAutoDestroy = false;
        StartCoroutine(AutoDestroy());
    }


    private void OnDestroy() {
        if(targetController != null && isAutoDestroy == false)
            targetController.SetDoublePoints(10);
    }

    IEnumerator AutoDestroy(){
        yield return new WaitForSecondsRealtime(3f);
        isAutoDestroy = true;
        base.TakeDamage();
    }


}
