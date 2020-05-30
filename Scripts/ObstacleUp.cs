using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleUp : MonoBehaviour
{
    public float speed; //set later in unity
    public float switchTime; //set later in unity
    public GameObject collideEffect;

    private Chicken chicken;

    // Start is called before the first frame update
    void Start()
    {
        chicken = FindObjectOfType<Chicken>();

        GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;

        //call the method 0 times, then repeat every switchTime seconds
        InvokeRepeating("Switch", 0, switchTime);
    }

    // Update is called once per frame
    void Update()
    {
        //
    }

    //reverse the rigibody's velocity
    private void Switch()
    {
        GetComponent<Rigidbody2D>().velocity *= -1;
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
