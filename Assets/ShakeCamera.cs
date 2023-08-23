using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    public float duration = 1f;
    public float magnitude = 0.1f;

    public GameObject explosionEffect;

    public AudioSource explosionSound;

    void Update()
    {
        if(TargetController.Instance.isShaking)
        {
            TargetController.Instance.isShaking = false;
            StartCoroutine(Shake(duration, magnitude));
        }
    }

    IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0f;
        Vector3 bombPos = new Vector3(4.02f, 3, -1.629f);
        GameObject explosion = Instantiate(explosionEffect, bombPos, transform.rotation);
        explosion.transform.localScale = new Vector3(2f, 2f, 2f);
        explosionSound.Play();
        while(elapsed < duration)
        {
            transform.localPosition = originalPos + Random.insideUnitSphere * magnitude;

            elapsed += Time.deltaTime;
            
            for(int i=TargetController.Instance.targetList.Count-1 ; i>=0 ; i--){
                TargetController.Instance.targetList[i].GetComponent<Target>().TakeDamage();
            }
            yield return null;
        }
        explosionSound.Stop();
        transform.localPosition = originalPos;
        Destroy(explosion);
    }
}
