using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{
    public GameObject player;
    private Movement mov;

    private void Start()
    {
        mov = player.GetComponent<Movement>();
    }
    public void Left()
    {
        mov.Left();
    }
    public void Right()
    {
        mov.Right();
    }

    public void RotateLeft()
    {
        mov.RotateLeft();
    }

    public void RotateRight()
    {
        mov.RotateRight();
    }
}
