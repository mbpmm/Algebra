using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{
    public GameObject player;
    public void Left()
    {
        player.transform.position = player.transform.position + new Vector3(0, 0, -1);
    }
    public void Right()
    {
        player.transform.position = player.transform.position + new Vector3(0, 0, 1);
    }
}
