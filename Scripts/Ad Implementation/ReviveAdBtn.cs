using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

[RequireComponent(typeof(Button))]
public class ReviveAdBtn : MonoBehaviour , IUnityAdsListener
{
#if UNITY_IOS
    private string gameId = "3573275";
#elif UNITY_ANDROID
    private string gameId = "3573275";
#endif

    Chicken chicken;
    Button watchVideoBtn;
    [SerializeField]
    GameObject gameoverCanvas;
    [SerializeField]
    Slider slider;
    [SerializeField]
    Button pauseButton;

    public string myPlacementId = "rewardedVideo";

    // Start is called before the first frame update
    void Start()
    {
        chicken = FindObjectOfType<Chicken>();
        watchVideoBtn = GetComponent<Button>();

        // set interactivity to be dependent on placement status
        watchVideoBtn.interactable = Advertisement.IsReady(myPlacementId);

        // map showReward to button's listener
        if (watchVideoBtn) watchVideoBtn.onClick.AddListener(ShowRewardVideo);

        // initialize ads listener and service
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, false);
    }

    // accessed outside this class
    public void RemoveAddListener()
    {
        Advertisement.RemoveListener(this);
    }

    void ShowRewardVideo()
    {
        Advertisement.Show(myPlacementId);
    }

    // implement unity ads interface methods ready error start finish
    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == myPlacementId)
        {
            watchVideoBtn.interactable = true;
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("Error: " + message);
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Ads started.");
        slider.value = 3f;
        gameoverCanvas.SetActive(false);
        pauseButton.interactable = true;
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            // revive and continue gameplay
            chicken.isDead = false;
            slider.value = 3;
            pauseButton.interactable = true;
            gameoverCanvas.gameObject.SetActive(false);
            Time.timeScale = 1;
            FindObjectOfType<Chicken>().GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f);
            Physics2D.IgnoreLayerCollision(8, 0, true);
            Invoke("NormalColor", 3f);
        }
        else if (showResult == ShowResult.Skipped)
        {
            chicken.isDead = false;
            slider.value = 3;
            gameoverCanvas.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");

            // continue countdown timer
            slider.value = 3;
            gameoverCanvas.gameObject.SetActive(true);
        }
    }

    private void NormalColor()
    {
        FindObjectOfType<Chicken>().GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        Physics2D.IgnoreLayerCollision(8, 0, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
