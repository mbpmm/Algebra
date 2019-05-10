using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWallsRemaining : MonoBehaviour
{
    public GameObject wallManager;
    public Text wallsText;

    private WallsRemaining walls;
    private void Start()
    {
        walls = wallManager.GetComponent<WallsRemaining>();
    }

    // Update is called once per frame
    void Update()
    {
        wallsText.text = "Walls Remaining: " + walls.getWalls();
    }
}
