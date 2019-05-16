using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steps : MonoBehaviour
{
    private int steps;

    private void Awake()
    {
        steps = 20;
    }
    public void addStep()
    {
        steps--;
    }

    public int getSteps()
    {
        return steps;
    }
}
