using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* if pplanestat == 1 : pplane unlocked
 * if highscore >= 100,000 : usain who?
 * if cbootduration...&&...magnetduration >= 20 : all upgrades
 * if pplanestat..&&..eaglestat == 1 : all birds bought
 * ++the achievement pref every time one is unlocked.
 * if/when achievement pref reaches 4 (>=4) : achiever.
 */

public class Achievements : MonoBehaviour
{
    private int achievement;

    private int pPlaneStat, hBirdStat, wPeckerStat, eagleStat;

    private int highscore;

    private float totalCBootDuration, totalHBootDuration, totalGhostDuration, totalMagnetDuration;

    [SerializeField]
    GameObject planeUnlocked, usainWho, allUpgrades, allBirds, achiever;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Achievement", 0);

        pPlaneStat = PlayerPrefs.GetInt("pPlaneStat");
        hBirdStat = PlayerPrefs.GetInt("hBirdStat");
        wPeckerStat = PlayerPrefs.GetInt("wPeckerStat");
        eagleStat = PlayerPrefs.GetInt("EagleStat");

        highscore = PlayerPrefs.GetInt("Highscore");

        totalCBootDuration = PlayerPrefs.GetFloat("CBootDuration");
        totalHBootDuration = PlayerPrefs.GetFloat("HBootDuration");
        totalGhostDuration = PlayerPrefs.GetFloat("GhostDuration");
        totalMagnetDuration = PlayerPrefs.GetFloat("MagnetDuration");

        achievement = PlayerPrefs.GetInt("Achievement");

        // check
        UnlockPlane();
        Highscore();
        AllUpgrades();
        AllBirds();
        Achiever();
    }

    private void UnlockPlane()
    {
        if (pPlaneStat == 1)
        {
            planeUnlocked.SetActive(true);
            achievement += 1;
            PlayerPrefs.SetInt("Achievement", achievement);
        }
    }

    private void Highscore()
    {
        if (highscore >= 100000)
        {
            usainWho.SetActive(true);
            achievement += 1;
            PlayerPrefs.SetInt("Achievement", achievement);
        }
    }

    private void AllUpgrades()
    {
        if ((totalCBootDuration >= 20) && (totalHBootDuration >= 20) && (totalGhostDuration >= 20) && (totalMagnetDuration >= 20))
        {
            allUpgrades.SetActive(true);
            achievement += 1;
            PlayerPrefs.SetInt("Achievement", achievement);
        }
    }

    private void AllBirds()
    {
        if ((pPlaneStat == 1) && (hBirdStat == 1) && (wPeckerStat == 1) && (eagleStat == 1))
        {
            allBirds.SetActive(true);
            achievement += 1;
            PlayerPrefs.SetInt("Achievement", achievement);
        }
    }

    private void Achiever()
    {
        if (achievement >= 4)
        {
            achiever.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
