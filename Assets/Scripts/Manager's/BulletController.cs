using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifetime = 5f;
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private LayerMask environment;

    private RaycastHit[] hit = new RaycastHit[10];

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        MoveProjectile();
        DetectTarget();
    }
    private void DetectTarget()
    {
        
        hit = Physics.SphereCastAll(transform.position, 0.1f, transform.forward, speed * Time.unscaledDeltaTime ,targetLayer);
        for(int i = 0 ; i < hit.Length ; i++)
        {
            hit[i].collider.GetComponentInParent<Target>().TakeDamage();
            PlayerData.Instance.targetsHit++;
        }
    }

    private void MoveProjectile()
    {
        transform.Translate(Vector3.forward * speed * Time.unscaledDeltaTime);
    }

}
