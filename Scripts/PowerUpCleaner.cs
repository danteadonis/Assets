using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCleaner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SpeedDown" | collision.gameObject.tag == "SpeedUp" | 
            collision.gameObject.tag == "GhostMode" | collision.gameObject.tag == "Magnet" | 
            collision.gameObject.tag == "Multiplier")
        {
            Destroy(collision.gameObject);
        }
    }
}
