using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverSlider : MonoBehaviour
{
    private Slider slider;
    private ReviveAdBtn reviveAd;

    // Start is called before the first frame update
    void Start()
    {
        slider = FindObjectOfType<Slider>().GetComponent<Slider>();
        slider.maxValue = 3f;
        slider.value = 3f;

        reviveAd = FindObjectOfType<ReviveAdBtn>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value -= .01f;
        if (slider.value <= .15f)
        {
            Time.timeScale = 1;
        }
        if (slider.value == 0f)
        {
            reviveAd.RemoveAddListener();
            SceneManager.LoadSceneAsync("Scene Loader");
        }
    }
}
