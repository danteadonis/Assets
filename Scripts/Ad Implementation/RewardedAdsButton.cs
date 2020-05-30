using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

[RequireComponent(typeof(Button))]
public class RewardedAdsButton : MonoBehaviour , IUnityAdsListener
{
#if UNITY_IOS
    private string gameId = "3573275";
#elif UNITY_ANDROID
    private string gameId = "3573275";
#endif

    Button watchAdBtn;

    public string myPlacementId = "rewardedVideo";
    public GameObject pickupSound;

    private int totalSeeds, totalEggs;

    [SerializeField]
    Text seedText, eggText, infoText;

    // Start is called before the first frame update
    void Start()
    {
        watchAdBtn = GetComponent<Button>();

        totalSeeds = PlayerPrefs.GetInt("SeedsTotal");
        totalEggs = PlayerPrefs.GetInt("EggsTotal");

        seedText.text = totalSeeds.ToString();
        eggText.text = totalEggs.ToString();

        // set interacticity to be dependent on the placement's status
        watchAdBtn.interactable = Advertisement.IsReady(myPlacementId);

        // map ShowRewardedVideo function to the button's click listener
        if (watchAdBtn) watchAdBtn.onClick.AddListener(ShowRewardedVideo);

        // initialize ads listener and service
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, false);
    }

    // accessed outside
    public void RemoveAddListener()
    {
        Advertisement.RemoveListener(this);
    }

    private void CoolDown() { watchAdBtn.gameObject.SetActive(true); }

    private void InfoOn() { infoText.gameObject.SetActive(true); }

    private void InfoOff() { infoText.gameObject.SetActive(false); }

    void ShowRewardedVideo()
    {
        Advertisement.Show(myPlacementId);
    }

    // implement IUnityAdsListener methods
    public void OnUnityAdsReady(string placementId)
    {
        // if ready placement is rewarded, activate button
        if (placementId == myPlacementId)
        {
            watchAdBtn.interactable = true;
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("Error: " + message);
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Ad started.");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            totalSeeds += 10;
            totalEggs += 5;
            PlayerPrefs.SetInt("SeedsTotal", totalSeeds);
            PlayerPrefs.SetInt("EggsTotal", totalEggs);
            InfoOn();
            Invoke("InfoOff", 2f);
            Instantiate(pickupSound, transform.position, Quaternion.identity);
            //watchAdBtn.gameObject.SetActive(false);
            watchAdBtn.interactable = false;
            Advertisement.RemoveListener(this);
            //Invoke("CoolDown", 5f);
        }
        else if (showResult == ShowResult.Skipped)
        {
            Debug.Log("Player skipped ad, no reward.");
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        seedText.text = totalSeeds.ToString();
        eggText.text = totalEggs.ToString();
    }
}
