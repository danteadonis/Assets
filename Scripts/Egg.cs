using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public bool isPulled = false;
    public GameObject eggSound, eggPickupEffect;

    private float eggSpeed = 15f;
    private Chicken chicken;
    private GameManager gameManager;
    private EggHolder eggHolder;
    private ScoreHolder scoreHolder;

    private void Start()
    {
        chicken = GameObject.FindWithTag("Player").GetComponent<Chicken>();  //fixed the null reference error
        gameManager = FindObjectOfType<GameManager>();

        eggHolder = FindObjectOfType<EggHolder>();
        scoreHolder = FindObjectOfType<ScoreHolder>();
    }

    private void Update()
    {
        if ((Vector2.Distance(transform.position, chicken.transform.position) < 12) && (isPulled == true))
        {
            transform.position = Vector2.MoveTowards(transform.position, chicken.transform.position, Time.deltaTime * eggSpeed);
        }
    }

    public void PullOn() { isPulled = true; }

    public void PullOff() { isPulled = false; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Instantiate(eggSound, transform.position, Quaternion.identity);
            Instantiate(eggPickupEffect, transform.position, Quaternion.identity);
            eggHolder.EggCounter();
            scoreHolder.score += 100;
            Destroy(gameObject);
        }
    }
}
