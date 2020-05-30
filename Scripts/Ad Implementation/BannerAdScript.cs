using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class BannerAdScript : MonoBehaviour
{
    public string gameId = "3573275";
    public string placementId = "RegularBanner";
    public bool testMode = false;

    Scene gameScene;

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(gameId, testMode);
        StartCoroutine(ShowBannerWhenReady());

        gameScene = SceneManager.GetSceneByName("Game");
    }

    IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady(placementId))
        {
            yield return new WaitForSeconds(0.5f);
        }

        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(placementId);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameScene.isLoaded)
        {
            Advertisement.Banner.Hide();
        }
    }
}
