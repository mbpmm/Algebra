using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    public GameObject player;
    public GameObject wallMgr;
    public int maxPoints;
    public int stepPoints;
    public char grade;
    public int pointsTotal;
    public string levelName;

    private WallsRemaining walls;
    private Points points;
    private Steps steps;
    private UIGoToScene sceneSwitch;
    private bool gameOver;
    private bool inGameOverScene;
    private bool switchOnce;

    public override void Awake()
    {
        base.Awake();
        gameOver = false;
        points = player.GetComponent<Points>();
        steps = player.GetComponent<Steps>();
        walls = wallMgr.GetComponent<WallsRemaining>();
        sceneSwitch = GetComponent<UIGoToScene>();
    }

    private void Start()
    {
        checkCurrentLevel(SceneManager.GetActiveScene().name);
    }
    // Update is called once per frame
    void Update()
    {
        if ((steps.getSteps() <= 0 || walls.getWalls() <= 0) && !gameOver)
        {
            gameOver = true;

        }

        if (gameOver&&!inGameOverScene)
        {
            pointsTotal = points.getPoints() + steps.getSteps() * stepPoints;
            if (pointsTotal == maxPoints)
            {
                grade = 'S';
            }
            else if (pointsTotal >= maxPoints * 0.8f)
            {
                grade = 'A';
            }
            else if (pointsTotal >= maxPoints * 0.6f)
            {
                grade = 'B';
            }
            else if (pointsTotal >= maxPoints * 0.4f)
            {
                grade = 'C';
            }
            else if (pointsTotal >= maxPoints * 0.3f)
            {
                grade = 'D';
            }
            else if (pointsTotal >= maxPoints * 0.2f)
            {
                grade = 'E';
            }
            else
            {
                grade = 'F';
            }
            inGameOverScene = true;
            Invoke("GoToGameOver", 2f);
            if(!switchOnce)
            {
                levelName = SceneManager.GetActiveScene().name;
                switchOnce = true;
            }
        }
    }

    public void GoToGameOver()
    {
        gameOver = false;
        sceneSwitch.sceneName = "GameOver";
        sceneSwitch.GoToScene();
    }

    public void checkCurrentLevel(string sceneName)
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            AudioManager.Get().PlayMusic("SongLevel1");
        }
        if (SceneManager.GetActiveScene().name == "Level2")
        {
            AudioManager.Get().PlayMusic("SongLevel2");
        }
    }
}
