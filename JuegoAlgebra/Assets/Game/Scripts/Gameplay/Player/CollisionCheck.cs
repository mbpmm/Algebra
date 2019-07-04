using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    public GameObject wallManager;
    public Transform transformPlayer;

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

                    Vector3 auxRot = wall.gameObject.GetComponentInParent<PerfectMatch>().rot;
                    Vector3 playerRot = transformPlayer.localRotation.eulerAngles;
                    Vector3 perfectRotOpposite;

                    auxRot.x = (playerRot.x + 360) % 360;
                    auxRot.y = (playerRot.y + 360) % 360;
                    auxRot.z = (playerRot.z + 360) % 360;

                    perfectRotOpposite.x = 360 - auxRot.x;
                    perfectRotOpposite.y = 360 - auxRot.y;
                    perfectRotOpposite.z = 360 - auxRot.z;   

                    Debug.Log("Perfect Rotation: " + auxRot);
                    Debug.Log("Perfect Rotation Opposite: " + perfectRotOpposite);
                    Debug.Log("Player Rotation: " + playerRot);

                    if (playerRot == auxRot || playerRot == perfectRotOpposite)
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
