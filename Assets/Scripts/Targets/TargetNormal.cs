using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetNormal : Target
{
    private ScoreManager scoreManager;
    private float value;

    private void Awake()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    protected override void Update()
    {
        base.Update();
        value = TargetController.Instance.Value;
    }


    private void OnDestroy() {
        scoreManager.AddScore((int)value);
    }

}
