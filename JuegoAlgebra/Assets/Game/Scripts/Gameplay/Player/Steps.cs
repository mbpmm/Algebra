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
    public void substractStep()
    {
        steps--;
        if (steps<=0)
        {
            steps = 0;
        }
    }

    public int getSteps()
    {
        return steps;
    }
}
