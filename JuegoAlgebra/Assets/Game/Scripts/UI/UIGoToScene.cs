using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGoToScene : MonoBehaviour
{
    public string sceneName;
    private GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    public void GoToScene()
    {
        if(SceneManager.GetActiveScene().name == "GameOver" && sceneName == "0")
        {
            SceneManager.LoadScene(gameManager.GetComponent<GameManager>().levelName);
        }
        else
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(sceneName);
        }
        
        Destroy(gameManager);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}
