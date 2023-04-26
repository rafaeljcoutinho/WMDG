using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifetime = 5f;
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private LayerMask environment;

    private Collider[] colliders = new Collider[10];
    private RaycastHit[] hit = new RaycastHit[10];

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        MoveProjectile();
    }
    private void FixedUpdate()
    {
        DetectTarget();
    }
    private void DetectTarget()
    {
        
        hit = Physics.SphereCastAll(transform.position, 0.01f, transform.forward, speed * Time.deltaTime ,targetLayer);
        for(int i = 0 ; i < hit.Length ; i++)
        {
            hit[i].collider.GetComponentInParent<Target>().TakeDamage();
        }
        if (Physics.OverlapSphereNonAlloc(transform.position, 0.01f, colliders, targetLayer) != 0)
        {
            Destroy(this);
        }
    }
    private void OnDrawGizmos()
    {
        //Gizmos.DrawSphere(transform.position + Vector3.up * 0.1f, 0.01f);
    }

    private void MoveProjectile()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

}
