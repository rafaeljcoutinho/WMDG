using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Target : MonoBehaviour
{
    [SerializeField] private bool moveTarget;
    [SerializeField] private float speed;


    [SerializeField] private Vector3 initPosition;
    [SerializeField] private Vector3 finalPosition;
    private bool isMovingForward = true;
    private float startTime;   
    private float journeyLength; 
    private Bounds bounds;


    
   protected virtual void Update()
    {
        transform.localScale = TargetController.Instance.CurrentScale;
        float journeyTime = Time.time - startTime;
        float totalJourneyTime = journeyLength / speed; // Tempo total para completar a jornada de ida e volta

        float fracJourney = Mathf.PingPong(journeyTime / totalJourneyTime, 1.0f);
        Vector3 newPosition = Vector3.Lerp(initPosition, finalPosition, fracJourney);

        if (!isMovingForward)
        {
            newPosition = Vector3.Lerp(finalPosition, initPosition, fracJourney);
        }

        transform.position = newPosition;
    }


    public virtual void TakeDamage()
    {
        TargetController.Instance.RespawnTargetInBounds(bounds);
        Destroy(gameObject);
    }


    public virtual void SetupTarget(Vector3 initialPosition, Vector3 finalPosition, Vector3 scale, bool isMove, float speed, Bounds bounds)
    {
        this.initPosition = initialPosition;
        this.finalPosition = finalPosition;
        transform.localScale = scale;
        this.moveTarget = isMove;
        this.speed = speed;
        this.bounds = bounds;

        startTime = Time.time;
        journeyLength = Vector3.Distance(initPosition, finalPosition);

    }

}
