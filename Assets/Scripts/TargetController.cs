using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public static TargetController Instance;
    [SerializeField] private Target targetPrefab;
    [SerializeField] private List<BoxCollider> SpawnAreas;
    [SerializeField] private float minTimerToSpawn;
    [SerializeField] private float maxTimerToSpawn;
    [SerializeField] private float scaleChangeSpeed;

    private Vector3 currentScale; 
    private int playerShoots;
    private int playerKills;
    private float speed;
    private int value;
    private Vector3 targetSize;

    public int Value => value;
    public Vector3 CurrentScale => currentScale;

    void Awake(){
        scaleChangeSpeed = 4.0f;
        targetSize = new Vector3(1,1,1);
        minTimerToSpawn = 0f;
        maxTimerToSpawn = 8.5f;
        speed = 1;
        playerKills = 6;
        playerShoots = 10;
        if(Instance == null){
            Instance = this;
        }else
            Destroy(gameObject);
        
        foreach(BoxCollider b in SpawnAreas){
            Vector3 minBounds = b.bounds.min;
            Vector3 maxBounds = b.bounds.max;

            Vector3 randomInitPosition = new Vector3(
                Random.Range(minBounds.x, maxBounds.x),
                Random.Range(minBounds.y, maxBounds.y),
                Random.Range(minBounds.z, maxBounds.z)
            );
            Vector3 randomFinalPosition = new Vector3(
                Random.Range(minBounds.x, maxBounds.x),
                Random.Range(minBounds.y, maxBounds.y),
                Random.Range(minBounds.z, maxBounds.z)
            );
            Target newTarget = Instantiate(targetPrefab);
            newTarget.SetupTarget(randomInitPosition, randomFinalPosition, targetSize, true, speed, b.bounds);
        }
    }

    public void RespawnTargetInBounds(Bounds bounds)
    {
        // Aguarde o tempo de respawn antes de instanciar um novo alvo
        float time = Random.Range(minTimerToSpawn, maxTimerToSpawn);
        StartCoroutine(RespawnCoroutine(bounds, time));
    }

    private IEnumerator RespawnCoroutine(Bounds bounds, float respawnTime)
    {
        playerKills++;
        yield return new WaitForSeconds(respawnTime);

        Vector3 minBounds = bounds.min;
        Vector3 maxBounds = bounds.max;

        Vector3 randomInitPosition = new Vector3(
            Random.Range(minBounds.x, maxBounds.x),
            Random.Range(minBounds.y, maxBounds.y),
            Random.Range(minBounds.z, maxBounds.z)
        );
        Vector3 randomFinalPosition = new Vector3(
            Random.Range(minBounds.x, maxBounds.x),
            Random.Range(minBounds.y, maxBounds.y),
            Random.Range(minBounds.z, maxBounds.z)
        );
        Target newTarget = Instantiate(targetPrefab);

        newTarget.SetupTarget(randomInitPosition, randomFinalPosition, targetSize, true, speed, bounds);
    }
    private void Update() {
        if(playerShoots%10 == 0)
            CalculateDificulty();



        if (currentScale != targetSize)
        {
            currentScale = Vector3.Lerp(currentScale, targetSize, Time.deltaTime * scaleChangeSpeed);
            transform.localScale = currentScale;
        }
    }

    public void PlayerShoot(){
        playerShoots++;
    }

    public void CalculateDificulty(){
        float playerStats = (float)playerKills / (float)playerShoots;
        float scale = targetSize.x;
        if(playerStats > 0.85f){
            speed = 5f;
            scale = 0.5f;
            value = 25;
        }
        else if(playerStats > 0.7f){
            speed = 3f;
            scale = 0.75f;
            value = 15;
        }
        else if(playerStats >= 0.6f){
            speed = 1;
            scale = 1f;
            value = 10;
        }
        else if(playerStats > 0.4f){
            speed = 0.7f;
            scale = 1.25f;
            value = 5;
        }
        else{
            speed = 0.3f;
            scale = 1.5f;
            value = 1;
        }
        targetSize = new Vector3(scale, scale, scale);
    }


}
