using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private float spawnInterval;

    public GameObject obstacleToSpawn;
    public float delayTime;
    public float decreaseTime;
    public float minTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        //
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnInterval <= 0)
        {
            Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);
            spawnInterval = delayTime;
            if (delayTime > minTime)
            {
                delayTime -= decreaseTime;
            }
        }
        else
        {
            spawnInterval -= Time.deltaTime;
        }
    }
}
