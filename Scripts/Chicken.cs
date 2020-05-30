using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Chicken : MonoBehaviour
{
    public float speed = 10;
    public float flapForce = 5;
    public bool isDead = false;
    public Text eggInfo, highScore;
    public Rigidbody2D rigidbody2D;
    public GameManager gameManager;
    public SpriteRenderer spriteRenderer;
    public GameObject gameOverObjects;
    public Seed seed;
    public Egg egg;
    public GameObject birdCollideSound, flapSound, powerDownSound, pickupEffect;
    public CharacterHandler characterHandler;

    private int characterStat;
    private float yPosition;
    private bool isInvisible = false;
    public ScoreHolder scoreHolder;
    private SeedHolder seedHolder;
    private EggHolder eggHolder;
    private PowerUp powerUp;
    [SerializeField]
    private Slider gameOverSlider;
    [SerializeField]
    private Button pauseButton;

    // Start is called before the first frame update
    void Start()
    {
        eggInfo.text = "Out Of Eggs!";
        highScore.text = "New Highscore!!!";
        rigidbody2D = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        //StartCoroutine(IncreaseScore());
        InvokeRepeating("IncreaseScore", .5f, .1f); //invoke method at .5secs, every .1sec.

        /*seed.isPulled = false;
        egg.isPulled = false;*/
        if (seed.isPulled == true)
        {
            seed.isPulled = false;
        }
        if (egg.isPulled == true)
        {
            egg.isPulled = false;
        }

        characterHandler.CharacterController();

        characterStat = PlayerPrefs.GetInt("CharacterStat");
        yPosition = transform.position.y;
        isInvisible = false;
        scoreHolder = FindObjectOfType<ScoreHolder>().GetComponent<ScoreHolder>();
        seedHolder = FindObjectOfType<SeedHolder>().GetComponent<SeedHolder>();
        eggHolder = FindObjectOfType<EggHolder>().GetComponent<EggHolder>();

        powerUp = FindObjectOfType<PowerUp>();
        Time.timeScale = 1;

        //gameOverObjects = GameObject.FindWithTag("GameOver");
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);

        //flap when user clicks, then increase speed at steady pace
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(flapSound, transform.position, Quaternion.identity);
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, flapForce);

            //GetComponent<Rigidbody2D>().AddForce(Vector2.up * flapForce);
        }

        speed += 0.005f / 5;
        PlayerPrefs.SetInt("SeedsTotal", seedHolder.seeds + seedHolder.seedsPerSession);
        PlayerPrefs.SetInt("EggsTotal", eggHolder.eggs + eggHolder.eggsPerSession);
    }

    public void Lose()
    {
        isDead = true;
        Time.timeScale = 0;
        gameOverObjects.SetActive(true);
        pauseButton.interactable = false;
        Physics2D.IgnoreLayerCollision(8, 0, false);   // undo ghost effect layer ignore collision stuff thing ;)
        //this.gameObject.SetActive(false);

        //  saving system
        if (PlayerPrefs.GetInt("Highscore") < scoreHolder.score)
        {
            PlayerPrefs.SetInt("Highscore", scoreHolder.score);
            ShowHighscore();
            Invoke("ClearHighscore", 1f);
        }

        PlayerPrefs.Save(); // save all values
    }

    public void Revive()
    {
        characterHandler.CharacterController();

        if (eggHolder.eggs >= 1)
        {
            eggHolder.eggs -= 1;
            PlayerPrefs.SetInt("EggsTotal", eggHolder.eggs + eggHolder.eggsPerSession);

            gameOverObjects.SetActive(false);
            pauseButton.interactable = true;
            IncreaseScore();

            gameOverSlider.value = 3f;

            // reset the position of the character to the center of the screen and move forward a bit.
            if (transform.position.y > 0 | transform.position.y < 0)
            {
                transform.position = new Vector2(transform.position.x + 5, yPosition);
            }

            TempGhost();
            Invoke("CancelGhostEffect", 3);
            isDead = false;
            Time.timeScale = 1;
            
            //if chicken position y too far out, lose. (if chicken drifts too far out vertically, lose.)
            if (this.transform.position.y > 10 || this.transform.position.y < -10)
            {
                Lose();
            }
        }
        else
        {
            ShowEggInfo();
            Invoke("ClearEggInfo", 1.5f);
        }
    }

    private void TempGhost()
    {
        FindObjectOfType<Chicken>().GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f);
        Physics2D.IgnoreLayerCollision(8, 0, true);
    }
    private void CancelGhostEffect()
    {
        //yield return new WaitForSeconds(3);
        Instantiate(powerDownSound, transform.position, Quaternion.identity);
        FindObjectOfType<Chicken>().GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        Physics2D.IgnoreLayerCollision(8, 0, false);

        //  if the character game object drifts too far out vertically, lose.
        if (transform.position.y > 10 || transform.position.y < -10)
        {
            Lose();
        }
    }

    private void ShowEggInfo()
    {
        eggInfo.gameObject.SetActive(true);
    }
    private void ShowHighscore()
    {
        highScore.gameObject.SetActive(true);
    }

    private void ClearEggInfo()
    {
        //yield return new WaitForSeconds(2);
        eggInfo.gameObject.SetActive(false);
    }
    private void ClearHighscore()
    {
        highScore.gameObject.SetActive(false);
    }

    public void Invisible()
    {
        isInvisible = true; //private
    }
    public void NotInvisible() { isInvisible = false; }

    public void SlowMo() { Time.timeScale = 0.5f; }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Obstacle" && isInvisible == false)
        {
            Instantiate(birdCollideSound, transform.position, Quaternion.identity);
            SlowMo();
            seed.isPulled = false;
            egg.isPulled = false;
            Invoke("Lose", .3f);
        }

        while(col.gameObject.tag == "")
        {
            //IncreaseScore();
            InvokeRepeating("IncreaseScore", .5f, .1f);
        }

        //power up collisions start here
        if(col.gameObject.tag == "SpeedUp")
        {
            Instantiate(pickupEffect, transform.position, Quaternion.identity);
            powerUp.SpeedUp();
            scoreHolder.score += 100;
            StartCoroutine(powerUp.SpeedBackToNormal());
        }

        if (col.gameObject.tag == "SpeedDown")
        {
            Instantiate(pickupEffect, transform.position, Quaternion.identity);
            powerUp.SpeedDown();
            scoreHolder.score += 100;
            StartCoroutine(powerUp.SpeedDownCancel());
        }

        if (col.gameObject.tag == "GhostMode")
        {
            if (!isInvisible)
            {
                Instantiate(pickupEffect, transform.position, Quaternion.identity);
                powerUp.GhostMode();
                scoreHolder.score += 100;
                StartCoroutine(powerUp.NormalMode());
            }
        }

        if (col.gameObject.tag == "Magnet")
        {
            Instantiate(pickupEffect, transform.position, Quaternion.identity);
            powerUp.Magnet();
            scoreHolder.score += 100;
            StartCoroutine(powerUp.MagnetCancel());
        }

        if (col.gameObject.tag == "Multiplier")
        {
            Instantiate(pickupEffect, transform.position, Quaternion.identity);
            powerUp.ScoreMultiplier();
        }
    }

    //increase score every millisecond
    private void IncreaseScore()
    {
        //while (true)
        //{
            //yield return new WaitForSeconds(.1f);
            scoreHolder.score++;
        //}
    }

    /*public void ShowGameOver()
    {
        foreach (GameObject gameObject in gameOverObjects)
        {
            gameObject.SetActive(true);
        }
    }*/

    /*public void HideGameOver()
    {
        foreach(GameObject gameObject in gameOverObjects)
        {
            gameObject.SetActive(false);
        }
        gameOverObjects.SetActive(false);
    }*/
}
