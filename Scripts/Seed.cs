using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    public bool isPulled = false;
    public GameObject seedSound, seedPickupEffect;

    private float seedSpeed = 15f;
    private Chicken chicken;
    private GameManager gameManager;
    private SeedHolder seedHolder;
    private ScoreHolder scoreHolder;

    private void Start()
    {
        chicken = GameObject.FindWithTag("Player").GetComponent<Chicken>();
        gameManager = FindObjectOfType<GameManager>();

        seedHolder = FindObjectOfType<SeedHolder>();
        scoreHolder = FindObjectOfType<ScoreHolder>();
    }

    private void Update()
    {
        if ((Vector2.Distance(transform.position, chicken.transform.position) < 12) && (isPulled == true))
        {
            transform.position = Vector2.MoveTowards(transform.position, chicken.transform.position, Time.deltaTime * seedSpeed);
        }
    }

    public void PullOn() { isPulled = true; }

    public void PullOff() { isPulled = false; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Instantiate(seedSound, transform.position, Quaternion.identity);
            Instantiate(seedPickupEffect, transform.position, Quaternion.identity);
            seedHolder.SeedCounter();
            scoreHolder.score += 10;
            Destroy(this.gameObject);
        }
    }
}
