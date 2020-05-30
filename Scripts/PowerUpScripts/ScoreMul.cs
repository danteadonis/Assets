using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMul : MonoBehaviour
{
    public GameObject powerUpSound;

    private Chicken chicken;

    // Start is called before the first frame update
    void Start()
    {
        chicken = GameObject.FindWithTag("Player").GetComponent<Chicken>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(powerUpSound, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
