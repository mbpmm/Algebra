using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public GameObject wallManager;

    private WallsRemaining walls;
    // Start is called before the first frame update
    void Start()
    {
        walls = wallManager.GetComponent<WallsRemaining>();
        walls.addWall();
    }
}
