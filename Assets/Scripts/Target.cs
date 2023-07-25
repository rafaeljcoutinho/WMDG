using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private bool moveTarget;
    [SerializeField] private float speed;
    [SerializeField] private int value;

    [SerializeField] private Vector3 initPosition;
    [SerializeField] private Vector3 finalPosition;
    private bool isMovingForward = true;
    private float startTime;   
    private float journeyLength; 
    private Bounds bounds;
    
    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }
   void Update()
    {
        transform.localScale = TargetController.Instance.CurrentScale;
        value = TargetController.Instance.Value;
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

    public void TakeDamage()
    {
        scoreManager.AddScore(value);
        TargetController.Instance.RespawnTargetInBounds(bounds);
        Destroy(gameObject);
    }

    public void SetupTarget(Vector3 initialPosition, Vector3 finalPosition, Vector3 scale, bool isMove, float speed, Bounds bounds)
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
