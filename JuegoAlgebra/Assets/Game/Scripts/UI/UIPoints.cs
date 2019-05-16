using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPoints : MonoBehaviour
{
    public GameObject player;
    public Text points;

    private Points playerPoints;
    private void Start()
    {
        playerPoints = player.GetComponent<Points>();
    }

    // Update is called once per frame
    void Update()
    {
        points.text = "Points: " + playerPoints.getPoints();
    }
}
