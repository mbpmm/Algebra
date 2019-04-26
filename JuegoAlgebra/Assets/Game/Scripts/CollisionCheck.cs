using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{

    //public GameObject wall;
    private MeshRenderer materialCubo;
    private void Start()
    {
        materialCubo = GetComponent<MeshRenderer>();
    }

    void OnTriggerEnter(Collider wall2)
    {
        Debug.Log("Colisiona");
        materialCubo.material.color = Color.red;
        
    }

    private void OnTriggerExit(Collider collision)
    {
        materialCubo.material.color = Color.white;
    }
}
