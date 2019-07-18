using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGoToScene : MonoBehaviour
{
    public string sceneName;
    private string levelSceneName;
    private GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");

        if (SceneManager.GetActiveScene().name == "GameOver" && sceneName == "0")
        {
            levelSceneName = gameManager.GetComponent<GameManager>().levelName;
        }

        if(SceneManager.GetActiveScene().name == "Level Selection")
        {
            DestroyManager();
        }
    }

    public void GoToScene()
    {
        ActiveSong.Get().CheckNextScene(sceneName);

        if(SceneManager.GetActiveScene().name == "Level1" || SceneManager.GetActiveScene().name == "Level2")
        {
            AudioManager.Get().audioSource.Stop();
        }

        if (SceneManager.GetActiveScene().name == "GameOver" && sceneName == "0")
        {
            SceneManager.LoadScene(levelSceneName);
        }
        else
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(sceneName);
        }

        Invoke("DestroyManager", 0.1f);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }

    private void DestroyManager()
    {
        Destroy(gameManager);
    }
}
