using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSystem : MonoBehaviour
{
    public Text cBootText;
    public Text hBootText;
    public Text ghostText;
    public Text magnetText;
    public Text infoText;
    public Text infoText_2;
    public Text seedAmtText;

    public GameObject c10, c15, c20, h10, h15, h20, g10, g15, g20, m10, m15, m20;

    private int totalSeeds;
    private float totalCBootDuration;
    private float totalHBootDuration;
    private float totalGhostDuration;
    private float totalMagnetDuration;
    
    // Start is called before the first frame update
    void Start()
    {
        cBootText.text = "50";
        hBootText.text = "50";
        ghostText.text = "50";
        magnetText.text = "50";
        infoText.text = "Not Enough Seeds!";
        infoText_2.text = "Maximum Level Reached!";

        totalSeeds = PlayerPrefs.GetInt("SeedsTotal");
        totalCBootDuration = PlayerPrefs.GetFloat("CBootDuration", 5);
        totalHBootDuration = PlayerPrefs.GetFloat("HBootDuration", 5);
        totalGhostDuration = PlayerPrefs.GetFloat("GhostDuration", 5);
        totalMagnetDuration = PlayerPrefs.GetFloat("MagnetDuration", 5);

        /*CBootDuration();
        HBootDuration();
        GDuration();
        MDuration();*/
    }

    public void CBootUpgrade()
    {
        if (PlayerPrefs.GetInt("SeedsTotal") >= 50)
        {
            if (totalCBootDuration >= 20)
            {
                Info_2();
                StartCoroutine(ClearInfo_2());
                totalCBootDuration = 20;    //set total value in player pref to 20.
            }
            totalSeeds -= 50;
            totalCBootDuration += 5;
            PlayerPrefs.SetFloat("CBootDuration", totalCBootDuration);
            PlayerPrefs.SetInt("SeedsTotal", totalSeeds);
            PlayerPrefs.Save();
        }
        else
        {
            Info();
            StartCoroutine(ClearInfo());
        }
    }

    public void HBootUpgrade()
    {
        if (PlayerPrefs.GetInt("SeedsTotal") >= 50)
        {
            if (totalHBootDuration >= 20)
            {
                Info_2();
                StartCoroutine(ClearInfo_2());
                totalHBootDuration = 20;
            }
            totalSeeds -= 50;
            totalHBootDuration += 5;
            PlayerPrefs.SetFloat("HBootDuration", totalHBootDuration);
            PlayerPrefs.SetInt("SeedsTotal", totalSeeds);
            PlayerPrefs.Save();
        }
        else
        {
            Info();
            StartCoroutine(ClearInfo());
        }
    }

    public void GhostUpgrade()
    {
        if (PlayerPrefs.GetInt("SeedsTotal") >= 50)
        {
            if (totalGhostDuration >= 20)
            {
                Info_2();
                StartCoroutine(ClearInfo_2());
                totalGhostDuration = 20;
            }
            totalSeeds -= 50;
            totalGhostDuration += 5;
            PlayerPrefs.SetFloat("GhostDuration", totalGhostDuration);
            PlayerPrefs.SetInt("SeedsTotal", totalSeeds);
            PlayerPrefs.Save();
        }
        else
        {
            Info();
            StartCoroutine(ClearInfo());
        }
    }

    public void MagnetUpgrade()
    {
        if (PlayerPrefs.GetInt("SeedsTotal") >= 50)
        {
            if (totalMagnetDuration >= 20)
            {
                Info_2();
                StartCoroutine(ClearInfo_2());
                totalMagnetDuration = 20;
            }
            totalSeeds -= 50;
            totalMagnetDuration += 5;
            PlayerPrefs.SetFloat("MagnetDuration", totalMagnetDuration);
            PlayerPrefs.SetInt("SeedsTotal", totalSeeds);
            PlayerPrefs.Save();
        }
        else
        {
            Info();
            StartCoroutine(ClearInfo());
        }
    }

    private void Info()
    {
        infoText.gameObject.SetActive(true);
    }

    private void Info_2()
    {
        infoText_2.gameObject.SetActive(true);
    }

    private IEnumerator ClearInfo()
    {
        yield return new WaitForSeconds(3);
        infoText.gameObject.SetActive(false);
    }

    private IEnumerator ClearInfo_2()
    {
        yield return new WaitForSeconds(3);
        infoText_2.gameObject.SetActive(false);
    }

    //i couldn't think of a better way to do this at the moment
    private void CBootDuration()
    {
        if (totalCBootDuration >= 10)
        {
            c10.SetActive(true);
        }
        if (totalCBootDuration >= 15)
        {
            c10.SetActive(true);
            c15.SetActive(true);
        }
        if (totalCBootDuration >= 20)
        {
            c10.SetActive(true);
            c15.SetActive(true);
            c20.SetActive(true);
        }
    }
    private void HBootDuration()
    {
        if (totalHBootDuration >= 10)
        {
            h10.SetActive(true);
        }
        if (totalHBootDuration >= 15)
        {
            h10.SetActive(true);
            h15.SetActive(true);
        }
        if (totalHBootDuration >= 20)
        {
            h10.SetActive(true);
            h15.SetActive(true);
            h20.SetActive(true);
        }
    }
    private void GDuration()
    {
        if (totalGhostDuration >= 10)
        {
            g10.SetActive(true);
        }
        if (totalGhostDuration >= 15)
        {
            g10.SetActive(true);
            g15.SetActive(true);
        }
        if (totalGhostDuration >= 20)
        {
            g10.SetActive(true);
            g15.SetActive(true);
            g20.SetActive(true);
        }
    }
    private void MDuration()
    {
        if (totalMagnetDuration >= 10)
        {
            m10.SetActive(true);
        }
        if (totalMagnetDuration >= 15)
        {
            m10.SetActive(true);
            m15.SetActive(true);
        }
        if (totalMagnetDuration >= 20)
        {
            m10.SetActive(true);
            m15.SetActive(true);
            m20.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        seedAmtText.text = totalSeeds.ToString();

        CBootDuration();
        HBootDuration();
        GDuration();
        MDuration();
    }
}
