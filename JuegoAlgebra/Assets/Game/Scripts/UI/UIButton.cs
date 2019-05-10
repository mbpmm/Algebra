using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{
    public GameObject player;
    private Steps playerSteps;
    private Movement mov;

    private void Start()
    {
        mov = player.GetComponent<Movement>();
        playerSteps = player.GetComponent<Steps>();
    }
    public void Left()
    {
        mov.Left();
        playerSteps.addStep();
    }
    public void Right()
    {
        mov.Right();
        playerSteps.addStep();
    }

    public void RotateLeft()
    {
        mov.RotateLeft();
        playerSteps.addStep();
    }

    public void RotateRight()
    {
        mov.RotateRight();
        playerSteps.addStep();
    }
}
