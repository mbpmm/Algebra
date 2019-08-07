using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameOver : MonoBehaviour
{
    public Text points;
    public Text grade;
    private GameObject gameManager;
    private GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        manager = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        points.text = "Total Points: " + manager.pointsTotal;
        grade.text = "Grade: " + manager.grade;
    }
}
