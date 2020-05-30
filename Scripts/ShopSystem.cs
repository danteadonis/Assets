using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour
{
    public Text infoTextSeeds;
    public Text infoTextEggs;
    public Text seedAmtText, eggAmtText;
    public GameObject pBuy, pSelect, hBuy, hSelect, wBuy, wSelect, eBuy, eSelect, selectedText;
    public Image pImage, hImage, wImage, eImage;
    public GameObject unlockSound;

    private int totalSeeds;
    private int totalEggs;
    private int pPlaneStat, hBirdStat, wPeckerStat, EagleStat;

    // Start is called before the first frame update
    void Start()
    {
        infoTextSeeds.text = "Not Enough Seeds! :)";
        infoTextEggs.text = "Not Enough Eggs! :)";

        totalSeeds = PlayerPrefs.GetInt("SeedsTotal");
        totalEggs = PlayerPrefs.GetInt("EggsTotal");

        pPlaneStat = PlayerPrefs.GetInt("pPlaneStat");
        hBirdStat = PlayerPrefs.GetInt("hBirdStat");
        wPeckerStat = PlayerPrefs.GetInt("wPeckerStat");
        EagleStat = PlayerPrefs.GetInt("EagleStat");

        //check state of 'buy' and 'select' buttons depending on value in playerprefs
        if (pPlaneStat == 1)
        {
            pImage.color = new Color(1f, 1f, 1f);
            pBuy.SetActive(false);
            pSelect.SetActive(true);
        }
        if (hBirdStat == 1)
        {
            hImage.color = new Color(1f, 1f, 1f);
            hBuy.SetActive(false);
            hSelect.SetActive(true);
        }
        if (wPeckerStat == 1)
        {
            wImage.color = new Color(1f, 1f, 1f);
            wBuy.SetActive(false);
            wSelect.SetActive(true);
        }
        if (EagleStat == 1)
        {
            eImage.color = new Color(1f, 1f, 1f);
            eBuy.SetActive(false);
            eSelect.SetActive(true);
        }
    }

    void Update()
    {
        seedAmtText.text = totalSeeds.ToString();
        eggAmtText.text = totalEggs.ToString();
    }

    //method to select chicken in gamemanager script.

    public void Paperplane()
    {
        if (totalSeeds >= 500)
        {
            totalSeeds -= 500;
            Instantiate(unlockSound, transform.position, Quaternion.identity);
            pImage.color = new Color(1f, 1f, 1f);
            PlayerPrefs.SetInt("CharacterStat", 1);
            PlayerPrefs.SetInt("pPlaneStat", 1);
            pSelect.SetActive(true);

            PlayerPrefs.SetInt("SeedsTotal", totalSeeds);
            PlayerPrefs.Save();
        }
        else
        {
            SeedsInfo();
            StartCoroutine(ClearSeedInfo());
        }
    }
    public void PSelect()
    {
        ShowSelectedText();
        StartCoroutine(HideSelectedText());
        PlayerPrefs.SetInt("CharacterStat", 1);
        PlayerPrefs.Save();
    }

    public void HBird()
    {
        if (totalSeeds >= 700)
        {
            totalSeeds -= 700;
            Instantiate(unlockSound, transform.position, Quaternion.identity);
            hImage.color = new Color(1f, 1f, 1f);
            PlayerPrefs.SetInt("CharacterStat", 2);
            PlayerPrefs.SetInt("hBirdStat", 1);
            hSelect.SetActive(true);

            PlayerPrefs.SetInt("SeedsTotal", totalSeeds);
            PlayerPrefs.Save();
        }
        else
        {
            SeedsInfo();
            StartCoroutine(ClearSeedInfo());
        }
    }
    public void HSelect()
    {
        ShowSelectedText();
        StartCoroutine(HideSelectedText());
        PlayerPrefs.SetInt("CharacterStat", 2);
        PlayerPrefs.Save();
    }

    public void WPecker()
    {
        if (totalEggs >= 100)
        {
            totalEggs -= 100;
            Instantiate(unlockSound, transform.position, Quaternion.identity);
            wImage.color = new Color(1f, 1f, 1f);
            PlayerPrefs.SetInt("CharacterStat", 3);
            PlayerPrefs.SetInt("wPeckerStat", 1);
            wSelect.SetActive(true);

            PlayerPrefs.SetInt("EggsTotal", totalEggs);
            PlayerPrefs.Save();
        }
        else
        {
            EggsInfo();
            StartCoroutine(ClearEggInfo());
        }
    }
    public void WSelect()
    {
        ShowSelectedText();
        StartCoroutine(HideSelectedText());
        PlayerPrefs.SetInt("CharacterStat", 3);
        PlayerPrefs.Save();
    }

    public void Eagle()
    {
        if (totalEggs >= 200)
        {
            totalEggs -= 200;
            Instantiate(unlockSound, transform.position, Quaternion.identity);
            eImage.color = new Color(1f, 1f, 1f);
            PlayerPrefs.SetInt("CharacterStat", 4);
            PlayerPrefs.SetInt("EagleStat", 1);
            eSelect.SetActive(true);

            PlayerPrefs.SetInt("EggsTotal", totalEggs);
            PlayerPrefs.Save();
        }
        else
        {
            EggsInfo();
            StartCoroutine(ClearEggInfo());
        }
    }
    public void ESelect()
    {
        ShowSelectedText();
        StartCoroutine(HideSelectedText());
        PlayerPrefs.SetInt("CharacterStat", 4);
        PlayerPrefs.Save();
    }

    private void SeedsInfo()
    {
        infoTextSeeds.gameObject.SetActive(true);
    }
    private void EggsInfo()
    {
        infoTextEggs.gameObject.SetActive(true);
    }

    private IEnumerator ClearSeedInfo()
    {
        yield return new WaitForSeconds(2);
        infoTextSeeds.gameObject.SetActive(false);
    }
    private IEnumerator ClearEggInfo()
    {
        yield return new WaitForSeconds(2);
        infoTextEggs.gameObject.SetActive(false);
    }

    private void ShowSelectedText()
    {
        selectedText.SetActive(true);
    }
    private IEnumerator HideSelectedText()
    {
        yield return new WaitForSeconds(2);
        selectedText.SetActive(false);
    }
}
