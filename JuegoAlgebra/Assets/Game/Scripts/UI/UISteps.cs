using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISteps : MonoBehaviour
{
    public GameObject player;
    public Text steps;

    private Steps playerSteps;
    private void Start()
    {
        playerSteps = player.GetComponent<Steps>();
    }

    // Update is called once per frame
    void Update()
    {
        steps.text = "Steps: " + playerSteps.getSteps();
    }
}
