using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    public float wallSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(1*Time.deltaTime*wallSpeed, 0, 0);
    }
}
