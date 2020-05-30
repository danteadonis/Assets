using UnityEngine;
using UnityEngine.Advertisements;

public class RewardedAdScript : MonoBehaviour , IUnityAdsListener
{
    string gameId = "3573275";
    string myPlacementId = "rewardedVideo";
    bool testMode = false;

    private int totalSeeds;
    private int totalEggs;

    // initialize ads listener and service
    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);

        totalSeeds = PlayerPrefs.GetInt("SeedsTotal");
        totalEggs = PlayerPrefs.GetInt("EggsTotal");
    }

    // implement IUnityAdsListener interface methods
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            totalSeeds += 10;
            totalEggs += 5;
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

    public void OnUnityAdsReady(string placementId)
    {
        // if placement is rewarded, show ad.
        if (placementId == myPlacementId)
        {
            Advertisement.Show(myPlacementId);
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // log error
        Debug.Log("Error: " + message);
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // optional action to perform when user triggers an ad.
        Debug.Log("Ad started.");
    }
}
