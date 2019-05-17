using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISteps : MonoBehaviour
{
    public GameObject player;
    public Text steps;
    public int textSize;
    private Steps playerSteps;
    private void Start()
    {
        textSize = 69;
        playerSteps = player.GetComponent<Steps>();
    }

    // Update is called once per frame
    void Update()
    {
        steps.text = "Steps: " + playerSteps.getSteps();
        int f = 2;
        for (int i = 5; i > 0; i--)
        {
            if (playerSteps.getSteps() <= i)
            {
                steps.color = Color.red;
                steps.fontSize = textSize+f;
                f += 2;
            }
        }
    }
}
