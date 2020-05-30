using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHandler : MonoBehaviour
{
    public GameObject chicken, paperplane, hummingbird, woodpecker, eagle;
    private int characterPlayerPref;

    // Start is called before the first frame update
    void Start()
    {
        characterPlayerPref = PlayerPrefs.GetInt("CharacterStat");
        CharacterController();
    }

    public void CharacterController()
    {
        switch (characterPlayerPref)
        {
            case 0:
                chicken.SetActive(true);

                paperplane.SetActive(false);
                hummingbird.SetActive(false);
                woodpecker.SetActive(false);
                eagle.SetActive(false);
                break;
            case 1:
                paperplane.SetActive(true);

                chicken.SetActive(false);
                hummingbird.SetActive(false);
                woodpecker.SetActive(false);
                eagle.SetActive(false);
                break;
            case 2:
                hummingbird.SetActive(true);

                chicken.SetActive(false);
                paperplane.SetActive(false);
                woodpecker.SetActive(false);
                eagle.SetActive(false);
                break;
            case 3:
                woodpecker.SetActive(true);

                chicken.SetActive(false);
                paperplane.SetActive(false);
                hummingbird.SetActive(false);
                eagle.SetActive(false);
                break;
            case 4:
                eagle.SetActive(true);

                chicken.SetActive(false);
                paperplane.SetActive(false);
                hummingbird.SetActive(false);
                woodpecker.SetActive(false);
                break;
            default:
                chicken.SetActive(true);

                paperplane.SetActive(false);
                hummingbird.SetActive(false);
                woodpecker.SetActive(false);
                eagle.SetActive(false);
                break;
        }
    }
}
