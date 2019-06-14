using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    public GameObject wallManager;

    //public GameObject wallParent;
    private Transform transformPlayer;
    private MeshRenderer materialCubo;
    private WallsRemaining walls;
    private Points playerPoints;
    private void Start()
    {
        transformPlayer = GetComponent<Transform>();
        materialCubo = GetComponent<MeshRenderer>();
        playerPoints = GetComponentInParent<Points>();
        walls = wallManager.GetComponent<WallsRemaining>();
        //wallParent = GetComponentInParent<GameObject>();
    }

    void OnTriggerEnter(Collider wall)
    {
        switch (wall.gameObject.tag)
        {
            case "wall":
                Debug.Log("Colisiona con pared.");
                materialCubo.material.color = Color.red;
                playerPoints.substractPoints(50);
                break;
            case "wallTrigger":
                walls.substractWall();

                if(materialCubo.material.color != Color.red)
                {
                    
                    Vector3 auxRot = wall.gameObject.GetComponentInParent<PerfectMatch>().rot;
                    Vector3 playerRot = transformPlayer.localRotation.eulerAngles;
                    Debug.Log(auxRot);

                    //PerfectMatch wallMatch = wall.gameObject.GetComponent<PerfectMatch>();
                    //
                    playerPoints.addPoints(100);
                    Debug.Log(auxRot * -1);
                    Debug.Log(transformPlayer.localRotation.eulerAngles);
                    if (playerRot == auxRot || playerRot == auxRot * -1)
                    {
                        playerPoints.addPoints(100);
                    }
                }
                break;
            default:
                break;
        }
    }

    private void OnTriggerExit(Collider wall)
    {
        switch (wall.gameObject.tag)
        {
            case "wall":
                Debug.Log("Dejo de colisionar con pared.");
                materialCubo.material.color = Color.white;
                break;
            default:
                break;
        }
    }
}
