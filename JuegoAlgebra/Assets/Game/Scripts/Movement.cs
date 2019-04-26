using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float limL;
    private float limR;
    // Start is called before the first frame update
    void Start()
    {
        limL = -3f;
        limR = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = transform.position + new Vector3(0, 0, -1);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = transform.position + new Vector3(0, 0, 1);
        }

        if (transform.position.z<limL)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, limL);
        }
        if (transform.position.z > limR)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, limR);
        }
    }
}
