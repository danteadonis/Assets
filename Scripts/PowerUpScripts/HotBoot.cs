using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotBoot : MonoBehaviour
{
    public float duration = 5;
    public GameObject powerUpSound, powerDownSound;
    public Slider hotSlider;

    private Chicken chicken;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetFloat("HBootDuration");
        hotSlider.maxValue = PlayerPrefs.GetFloat("HBootDuration", 5);
        hotSlider.value = PlayerPrefs.GetFloat("HBootDuration", 5);

        chicken = GameObject.FindWithTag("Player").GetComponent<Chicken>();
    }

    private void FixedUpdate()
    {
        if (hotSlider.gameObject.activeSelf)
        {
            hotSlider.value -= Time.fixedDeltaTime;
        }
    }

    public void PowerDownSound() { Instantiate(powerDownSound, transform.position, Quaternion.identity); }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(powerUpSound, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
