using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColdBoot : MonoBehaviour
{
    public float duration = 5;
    public GameObject powerUpSound, powerDownSound;
    public Slider coldSlider;

    private Chicken chicken;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetFloat("CBootDuration");
        coldSlider.maxValue = PlayerPrefs.GetFloat("CBootDuration", 5);
        coldSlider.value = PlayerPrefs.GetFloat("CBootDuration", 5);

        chicken = GameObject.FindWithTag("Player").GetComponent<Chicken>();
    }

    private void FixedUpdate()
    {
        if (coldSlider.gameObject.activeSelf)
        {
            coldSlider.value -= Time.fixedDeltaTime;
        }
    }

    public void PowerDownSound() { Instantiate(powerDownSound, transform.position, Quaternion.identity); }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(powerUpSound, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
