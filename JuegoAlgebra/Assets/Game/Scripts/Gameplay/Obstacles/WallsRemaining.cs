using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsRemaining : MonoBehaviour
{
    private int walls;

    public void substractWall()
    {
        walls--;
    }

    public void addWall()
    {
        walls++;
    }

    public int getWalls()
    {
        return walls;
    }
}
