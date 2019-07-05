﻿using System.Collections;
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
                    Vector3 perfectRotOpposite = new Vector3(0,0,0);

                    auxRot.x = (auxRot.x + 360) % 360;
                    auxRot.y = (auxRot.y + 360) % 360;
                    auxRot.z = (auxRot.z + 360) % 360;

                    if(wall.gameObject.GetComponentInParent<PerfectMatch>().hasX)
                    {
                        CheckOppositeRotation(auxRot.x, out perfectRotOpposite.x);
                    }

                    if(wall.gameObject.GetComponentInParent<PerfectMatch>().hasY)
                    {
                        CheckOppositeRotation(auxRot.y, out perfectRotOpposite.y);
                    }

                    if(wall.gameObject.GetComponentInParent<PerfectMatch>().hasZ)
                    {
                        CheckOppositeRotation(auxRot.z, out perfectRotOpposite.z);
                    }
                    

                    Debug.Log("Perfect Rotation: " + auxRot);
                    Debug.Log("Perfect Rotation Opposite: " + perfectRotOpposite);
                    Debug.Log("Player Rotation: " + playerRot);



                    if (playerRot == auxRot || playerRot == perfectRotOpposite && wall.gameObject.GetComponentInParent<PerfectMatch>().hasOpposite)
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

    private void CheckOppositeRotation(float rot1, out float rot2)
    {
        if (rot1 == 0)
        {
            rot2 = 180;
        }
        else
        {
            rot2 = 360 - rot1;
        }
    }
}
