using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private bool moveTarget;
    [SerializeField] private bool horizontal;
    [SerializeField] private bool vertical;
    [SerializeField] private float speed;
    [SerializeField] private float distance;
    [SerializeField] private int value;
    private int direction = 1;
    private ScoreManager scoreManager;
    private float traveled;

    private void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        traveled = 0;
    }
    private void Update()
    {
        if (moveTarget)
        {
            Move();
        }
    }

    private void Move()
    {
        Vector3 displacement = Vector3.zero;
        if (vertical)
        {
            displacement += Vector3.up;
        }
        if (horizontal)
        {
            displacement += Vector3.right;
        }
        displacement.Normalize();
        var nextPosition = displacement * speed * Time.deltaTime;
        traveled += nextPosition.magnitude;
        if(traveled >= distance)
        {
            direction *= -1;
            traveled = 0;
        }
        transform.position += nextPosition * direction;

    }

    public void TakeDamage()
    {
        scoreManager.AddScore(value);
        gameObject.SetActive(false);
    }


}
