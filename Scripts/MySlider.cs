using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* get specific powerup value
 * method to decrease value.
 * invoke repeating in collision.
 */

public class MySlider : MonoBehaviour
{
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = FindObjectOfType<Slider>().GetComponent<Slider>();
    }

    public void SetGhostSlider()
    {
        /*slider.maxValue = PlayerPrefs.GetFloat("GhostDuration", 5);
        slider.value = PlayerPrefs.GetFloat("GhostDuration", 5);
        InvokeRepeating("DecreaseGhostSlider", 0f, .1f);*/
    }
    public void DecreaseGhostSlider()
    {
        slider.value -= .1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
