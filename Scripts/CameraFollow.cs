using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject chicken, pPlane, hBird, wPecker, eagle;
    private int CharacterStat;

    void Start()
    {
        CharacterStat = PlayerPrefs.GetInt("CharacterStat");
    }

    // LateUpdate is called after everything in the scene has updated / loaded
    void LateUpdate()
    {
        /*transform.position = new Vector3(player.transform.position.x,
            transform.position.y,
            transform.position.z);*/

        switch (CharacterStat)
        {
            case 0:
                transform.position = new Vector3(chicken.transform.position.x,
                    transform.position.y,
                    transform.position.z);
                break;
            case 1:
                transform.position = new Vector3(pPlane.transform.position.x,
                    transform.position.y,
                    transform.position.z);
                break;
            case 2:
                transform.position = new Vector3(hBird.transform.position.x,
                    transform.position.y,
                    transform.position.z);
                break;
            case 3:
                transform.position = new Vector3(wPecker.transform.position.x,
                    transform.position.y,
                    transform.position.z);
                break;
            case 4:
                transform.position = new Vector3(eagle.transform.position.x,
                    transform.position.y,
                    transform.position.z);
                break;
            default:
                transform.position = new Vector3(chicken.transform.position.x,
                    transform.position.y,
                    transform.position.z);
                break;
        }
    }
}
