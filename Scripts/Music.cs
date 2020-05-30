using UnityEngine;

public class Music : MonoBehaviour
{
    private static Music music = null;

    public static Music TheMusic
    {
        get
        {
            return music;
        }
    }

    private void Awake()
    {
        //on awake check if music isn't null & not current music, else set to current music.
        if (music != null && music != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            music = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
