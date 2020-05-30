using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magnet : MonoBehaviour
{
    public float duration = 5;
    public GameObject powerUpSound, powerDownSound;
    public Slider magnetSlider;

    private Chicken chicken;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetFloat("MagnetDuration");
        magnetSlider.maxValue = PlayerPrefs.GetFloat("MagnetDuration", 5);
        magnetSlider.value = PlayerPrefs.GetFloat("MagnetDuration", 5);

        chicken = GameObject.FindWithTag("Player").GetComponent<Chicken>();
    }

    public void PowerDownSound() { Instantiate(powerDownSound, transform.position, Quaternion.identity); }

    // Update is called once per frame
    void Update()
    {
        if (magnetSlider.gameObject.activeSelf)
        {
            magnetSlider.value -= Time.fixedDeltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(powerUpSound, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
