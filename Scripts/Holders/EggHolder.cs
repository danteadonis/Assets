using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggHolder : MonoBehaviour
{
    public int eggs;
    public int eggsPerSession;

    public Text eggText;

    // Start is called before the first frame update
    void Start()
    {
        eggs = PlayerPrefs.GetInt("EggsTotal", 0);
        eggText.text = eggs.ToString();
    }

    /*public void EggAdder(int numOfEggs)
    {
        eggs += numOfEggs;
    }*/

    public void EggCounter()
    {
        eggsPerSession += 1;
    }
}
