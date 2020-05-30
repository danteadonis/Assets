using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetSpawner : MonoBehaviour
{
    private float spawnInterval;
    public GameObject magnet;

    private BoxCollider2D collider2D;

    // Start is called before the first frame update
    void Start()
    {
        spawnInterval = Random.Range(10, 100);

        collider2D = GetComponent<BoxCollider2D>();

        Invoke("MagnetInvoker", Random.Range(20, 200));
    }

    void MagnetInvoker() { StartCoroutine(MagnetSpawner1()); }

    IEnumerator MagnetSpawner1()
    {
        while (true)
        {
            float xRange = Random.Range(-collider2D.size.x, collider2D.size.x) * 5f;
            float yRange = Random.Range(-collider2D.size.y, collider2D.size.y) * 5f;

            GameObject gameObject = Instantiate<GameObject>(magnet);

            gameObject.transform.position = new Vector2(xRange + this.transform.position.x, yRange + this.transform.position.y);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
