using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class SeedSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float spawnInterval; //set in unity
    public float delayTime; //set in unity

    private BoxCollider2D collider2D;

    // Start is called before the first frame update
    void Start()
    {
        collider2D = GetComponent<BoxCollider2D>();

        //delay for delayTime seconds before invoking method.
        Invoke("ToInvoke", delayTime);
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
