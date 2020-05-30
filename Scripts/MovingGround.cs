using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGround : MonoBehaviour
{
    //public Chicken chicken;
    public GameObject chicken, pPlane, hBird, wPecker, eagle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(chicken.transform.position.x > this.transform.position.x)
        {
            this.transform.position = new Vector2(chicken.transform.position.x + 10, transform.position.y);
        }

        if (pPlane.transform.position.x > this.transform.position.x)
        {
            this.transform.position = new Vector2(pPlane.transform.position.x + 10, transform.position.y);
        }

        if (hBird.transform.position.x > this.transform.position.x)
        {
            this.transform.position = new Vector2(hBird.transform.position.x + 10, transform.position.y);
        }

        if (wPecker.transform.position.x > this.transform.position.x)
        {
            this.transform.position = new Vector2(wPecker.transform.position.x + 10, transform.position.y);
        }

        if (eagle.transform.position.x > this.transform.position.x)
        {
            this.transform.position = new Vector2(eagle.transform.position.x + 10, transform.position.y);
        }
    }
}
