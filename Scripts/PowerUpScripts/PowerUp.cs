using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    public Seed seed;
    public Egg egg;
    //public Slider hotSlider, ghostSlider;
    public GameObject cSlider, hSlider, gSlider, mSlider;

    private Chicken chicken;
    private GameManager gameManager;
    ScoreHolder scoreHolder;
    ColdBoot coldBoot;
    HotBoot hotBoot;
    Ghost ghost;
    Magnet magnet;

    // Start is called before the first frame update
    void Start()
    {
        /*hotSlider = FindObjectOfType<Slider>().GetComponent<Slider>();
        ghostSlider = FindObjectOfType<Slider>().GetComponent<Slider>();*/

        chicken = FindObjectOfType<Chicken>().GetComponent<Chicken>();
        gameManager = FindObjectOfType<GameManager>();
        scoreHolder = FindObjectOfType<ScoreHolder>();

        coldBoot = FindObjectOfType<ColdBoot>().GetComponent<ColdBoot>();
        hotBoot = FindObjectOfType<HotBoot>().GetComponent<HotBoot>();
        ghost = FindObjectOfType<Ghost>().GetComponent<Ghost>();
        magnet = FindObjectOfType<Magnet>().GetComponent<Magnet>();

        //PlayerPrefs.SetFloat("GhostDuration", ghost.duration);
    }

    // Update is called once per frame
    void Update()
    {
        //
    }

    //blue boot pick up
    public void SpeedDown()
    {
        cSlider.SetActive(true);
        Time.timeScale = 0.5f;
    }
    public IEnumerator SpeedDownCancel()
    {
        yield return new WaitForSeconds(PlayerPrefs.GetFloat("CBootDuration", coldBoot.duration));
        coldBoot.PowerDownSound();
        cSlider.SetActive(false);
        Time.timeScale = 1f;
    }

    //red boot pick up
    public void SpeedUp()
    {
        //chicken.speed *= 2;
        hSlider.SetActive(true);
        Time.timeScale *= 1.5f;
    }
    public IEnumerator SpeedBackToNormal()
    {
        yield return new WaitForSeconds(PlayerPrefs.GetFloat("HBootDuration", hotBoot.duration)); //default value if no purchase has been made yet in shop.
        hSlider.SetActive(false);
        hotBoot.PowerDownSound();
        //chicken.speed /= 2;
        Time.timeScale = 1;
    }

    //creepy ghost pick up
    public void GhostMode()
    {
        PlayerPrefs.GetFloat("GhostDuration");
        //ghostSlider.gameObject.SetActive(true);
        gSlider.SetActive(true);
        chicken.Invisible();
        FindObjectOfType<Chicken>().spriteRenderer.color = new Color(1f, 1f, 1f, .5f); //reduce opacity (make transparent)
        Physics2D.IgnoreLayerCollision(8, 0, true); //ingore collisions between a game object with layer 8 and one with layer 0.
    }
    public IEnumerator NormalMode()
    {
        yield return new WaitForSeconds(PlayerPrefs.GetFloat("GhostDuration", ghost.duration));
        //ghostSlider.gameObject.SetActive(false);
        gSlider.SetActive(false);
        chicken.NotInvisible();
        ghost.PowerDownSound();
        FindObjectOfType<Chicken>().spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        Physics2D.IgnoreLayerCollision(8, 0, false);

        //if chicken position y too far out, lose. (if chicken drifts too far out vertically, lose.)
        if(chicken.transform.position.y > 10 || chicken.transform.position.y < -10)
        {
            ghost.PowerDownSound();
            chicken.Lose();
        }
    }

    //magnet pick up
    public void Magnet()
    {
        mSlider.SetActive(true);
        seed.PullOn();
        egg.PullOn();
    }
    public IEnumerator MagnetCancel()
    {
        yield return new WaitForSeconds(PlayerPrefs.GetFloat("MagnetDuration", magnet.duration));
        magnet.PowerDownSound();
        mSlider.SetActive(false);
        seed.PullOff();
        egg.PullOff();
    }

    //score multiplier pickup
    public void ScoreMultiplier()
    {
        (scoreHolder.score) *= 2;
    }
}
