using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    public GameObject wallManager;

    private MeshRenderer materialCubo;
    private WallsRemaining walls;
    private Points playerPoints;
    private void Start()
    {
        materialCubo = GetComponent<MeshRenderer>();
        playerPoints = GetComponentInParent<Points>();
        walls = wallManager.GetComponent<WallsRemaining>();
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
                    playerPoints.addPoints(100);
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
