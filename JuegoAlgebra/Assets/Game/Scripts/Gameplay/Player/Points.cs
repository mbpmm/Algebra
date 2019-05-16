using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    private int points;

    public void addPoints(int newPoints)
    {
        points = points + newPoints;
    }

    public void substractPoints(int newPoints)
    {
        points = points - newPoints;
        if(points <= 0)
        {
            points = 0;
        }
    }

    public int getPoints()
    {
        return points;
    }
}
