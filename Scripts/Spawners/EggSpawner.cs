using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class EggSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;

    private float spawnInterval;
    private BoxCollider2D collider2D;

    // Start is called before the first frame update
    void Start()
    {
        //spawn every random seconds
        spawnInterval = Random.Range(20, 100);
        collider2D = GetComponent<BoxCollider2D>();

        //delay for random seconds before invoking method.
        Invoke("ToInvoke", Random.Range(20, 200));
    }

    public void ToInvoke()
    {
        //call method repeatedly
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        while (true)
        {
            float xRange = Random.Range(-collider2D.size.x, collider2D.size.x) * 5f;
            float yRange = Random.Range(-collider2D.size.y, collider2D.size.y) * 5f;

            GameObject gameObject = Instantiate<GameObject>(prefabToSpawn);

            gameObject.transform.position = new Vector2(xRange + this.transform.position.x, yRange + this.transform.position.y);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
