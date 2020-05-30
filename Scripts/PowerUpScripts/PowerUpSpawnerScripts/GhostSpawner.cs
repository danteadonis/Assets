using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    private float spawnInterval;
    public GameObject ghost;

    private BoxCollider2D collider2D;

    // Start is called before the first frame update
    void Start()
    {
        spawnInterval = Random.Range(10, 100);

        collider2D = GetComponent<BoxCollider2D>();

        Invoke("GhostInvoker", Random.Range(20, 200));
    }

    void GhostInvoker() { StartCoroutine(GhostSpawner1()); }

    IEnumerator GhostSpawner1()
    {
        while (true)
        {
            float xRange = Random.Range(-collider2D.size.x, collider2D.size.x) * 5f;
            float yRange = Random.Range(-collider2D.size.y, collider2D.size.y) * 5f;

            GameObject gameObject = Instantiate<GameObject>(ghost);

            gameObject.transform.position = new Vector2(xRange + this.transform.position.x, yRange + this.transform.position.y);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
