using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    public GameObject player;
    public GameObject wallMgr;
    public char grade;
    public int pointsTotal;

    private WallsRemaining walls;
    private Points points;
    private Steps steps;
    private bool gameOver;
    private int maxPoints;
    private int stepPoints;
    private bool inGameOverScene;

    public override void Awake()
    {
        base.Awake();
        stepPoints = 25;
        maxPoints = 750;
        gameOver = false;
        points = player.GetComponent<Points>();
        steps = player.GetComponent<Steps>();
        walls = wallMgr.GetComponent<WallsRemaining>();
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
        }

        Debug.Log(gameOver);
    }

    public void GoToGameOver()
    {
        //walls.addWall();
        //steps.addStep();
        inGameOverScene = false;
        gameOver = false;
        SceneManager.LoadScene("DemoGameOver");
    }
}
