using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeedHolder : MonoBehaviour
{
    public int seeds;
    public int seedsPerSession;

    public Text seedText;

    // Start is called before the first frame update
    void Start()
    {
        seeds = PlayerPrefs.GetInt("SeedsTotal", 0);
        seedText.text = seeds.ToString();
    }

    /*public void SeedAdder(int numOfSeeds)
    {
        //seeds += numOfSeeds;
        PlayerPrefs.SetInt("SeedsTotal", seeds + seedsPerSession);
    }*/

    public void SeedCounter()
    {
        seedsPerSession += 1;
    }
}
