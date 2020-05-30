using UnityEngine;

public class MusicController : MonoBehaviour
{
    public GameObject volumeOn, volumeOff, newAchievementText;
    private int achievementStatus;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        achievementStatus = PlayerPrefs.GetInt("Achievement");
        UpdateAchievement();

        audioSource = FindObjectOfType<AudioSource>();
        VolumeState();
    }

    private void UpdateAchievement()
    {
        switch (achievementStatus)
        {
            case 1:
                newAchievementText.SetActive(true);
                break;
            case 2:
                newAchievementText.SetActive(true);
                break;
            case 3:
                newAchievementText.SetActive(true);
                break;
            case 4:
                newAchievementText.SetActive(true);
                break;
            default:
                //newAchievementText.SetActive(false);
                break;
        }
    }

    public void ToggleVolume()
    {
        if (PlayerPrefs.GetInt("VolumeControl", 0) == 0)
        {
            PlayerPrefs.SetInt("VolumeControl", 1);
        }
        else
        {
            PlayerPrefs.SetInt("VolumeControl", 0);
        }

        VolumeState();
    }

    public void VolumeState()
    {
        if(PlayerPrefs.GetInt("VolumeControl", 0) == 0)
        {
            //AudioListener.volume = 1;
            audioSource.volume = 1;
            volumeOn.SetActive(true);
            volumeOff.SetActive(false);
        }
        else
        {
            //AudioListener.volume = 0;
            audioSource.volume = 0;
            volumeOn.SetActive(false);
            volumeOff.SetActive(true);
        }
    }
}
