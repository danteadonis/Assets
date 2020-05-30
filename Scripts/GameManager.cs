using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    public GUISkin guiLayout;
    public GameObject buttonSound;
    public Text scoreText, seedAmtText, eggAmtText;

    private ScoreHolder scoreHolder;
    private SeedHolder seedHolder;
    private EggHolder eggHolder;

    private int ChickenStat;

    AudioSource audioSource;
    GameObject chicken;
    GameObject[] pauseObjects;

    // Start is called before the first frame update
    void Start()
    {
        seedHolder = FindObjectOfType<SeedHolder>().GetComponent<SeedHolder>();
        scoreHolder = FindObjectOfType<ScoreHolder>().GetComponent<ScoreHolder>();
        eggHolder = FindObjectOfType<EggHolder>().GetComponent<EggHolder>();

        scoreText.text = (scoreHolder.score).ToString();
        seedAmtText.text = (seedHolder.seedsPerSession).ToString();
        eggAmtText.text = (eggHolder.eggsPerSession).ToString();

        ChickenStat = PlayerPrefs.GetInt("CharacterStat");

        audioSource = FindObjectOfType<AudioSource>();
        chicken = GameObject.FindGameObjectWithTag("Player");

        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("PauseControl");
        HidePaused();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > 0)
        {
            scoreText.text = (scoreHolder.score).ToString();
            seedAmtText.text = (seedHolder.seedsPerSession).ToString();
            eggAmtText.text = (eggHolder.eggsPerSession).ToString();
        }
    }

    public void PlayButtonSound() { Instantiate(buttonSound, transform.position, Quaternion.identity); }

    public void ChickenInShop()
    {
        PlayerPrefs.SetInt("CharacterStat", 0); //turns chicken to active in game scene
        PlayerPrefs.Save();
    }

    public void LoadScene(string theScene)
    {
        PlayerPrefs.Save();
        SceneManager.LoadSceneAsync(theScene);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
        Debug.Log("Quitting Game.");
#endif
    }

    public void PauseControl()
    {
        if(Time.timeScale >= 1)
        {
            Time.timeScale = 0;
            //audioSource.Pause();  no longer needed
            //chicken.SetActive(false);
            ShowPaused();
        }
        else
        {
            Time.timeScale = 1;
            //audioSource.UnPause();    no longer needed
            //chicken.SetActive(true);
            HidePaused();
        }
    }

    public void SetTimeScale() { Time.timeScale = 1; }

    public void ShowPaused()
    {
        foreach(GameObject gameObject in pauseObjects)
        {
            gameObject.SetActive(true);
        }
    }

    public void HidePaused()
    {
        foreach(GameObject gameObject in pauseObjects)
        {
            gameObject.SetActive(false);
        }
    }

    //no longer needed, used UI text in update method instead.
    /*private void OnGUI()
    {
        GUI.skin = guiLayout;
        GUI.Box(new Rect(Screen.width / 2 - 320 - 22, 8, 100, 25), "" + scoreHolder.score);
        GUI.Box(new Rect(Screen.width / 2 + 200 + 22, 8, 160, 27), "S: " + seedHolder.seedsPerSession + "     " + "E: " + eggHolder.eggsPerSession);
        if(GUI.Button(new Rect(Screen.width / 2 - 370 - 22, 8, 20, 20), "||"))
        {
            PauseControl();
        }
    }*/
}
