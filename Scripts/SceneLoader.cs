using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private bool loadScene = false;

    [SerializeField]
    private int sceneNumber;
    [SerializeField]
    private Text loadingText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (/*Input.GetKeyUp(KeyCode.Space) &&*/ loadScene == false)
        {
            loadScene = true;

            loadingText.text = "...Loading";

            StartCoroutine(LoadNewScene());
        }

        //if new scene has started loading
        if (loadScene == true)
        {
            //pulse text
            loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));
        }
    }

    private IEnumerator LoadNewScene()
    {
        yield return new WaitForSeconds(3);

        //load scene asynchronously in background
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneNumber);

        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }
}
