using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ghost : MonoBehaviour
{
    public float duration = 5f;
    public GameObject powerUpSound, powerDownSound;
    public Slider ghostSlider;

    private Chicken chicken;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetFloat("GhostDuration");
        ghostSlider.maxValue = PlayerPrefs.GetFloat("GhostDuration", 5);
        ghostSlider.value = PlayerPrefs.GetFloat("GhostDuration", 5);

        chicken = GameObject.FindWithTag("Player").GetComponent<Chicken>();
    }

    public void PowerDownSound() { Instantiate(powerDownSound, transform.position, Quaternion.identity); }

    private void FixedUpdate()
    {
        if (ghostSlider.gameObject.activeSelf)
        {
            ghostSlider.value -= Time.fixedDeltaTime;
        }
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
