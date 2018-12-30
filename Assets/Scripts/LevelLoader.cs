using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    [SerializeField] int waitTime = 3;
    int currentSceneIndex;

	// Use this for initialization
	void Start () {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
	}

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(waitTime);
        LoadNextScene();
    }
	
    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

	public void LoadYouLose()
    {
        SceneManager.LoadScene("Lose Screen");
    }

    public void LoadLastLevel()
    {
        SceneManager.LoadScene(currentSceneIndex - 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
