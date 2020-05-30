using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleStagnant : MonoBehaviour
{
    public GameObject collideEffect;
    private Chicken chicken;

    // Start is called before the first frame update
    void Start()
    {
        chicken = FindObjectOfType<Chicken>();
    }

    // Update is called once per frame
    void Update()
    {
        //
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(collideEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
