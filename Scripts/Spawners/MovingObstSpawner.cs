using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstSpawner : MonoBehaviour
{
    public float spawnInterval;
    public float delayTime;

    public GameObject obstacleToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Coroutine", delayTime);
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void Coroutine() { StartCoroutine(Spawn()); }

    // Update is called once per frame
    void Update()
    {
        
    }
}
