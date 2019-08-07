using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSong : MonoBehaviour
{
    public GameObject AM;
    private AudioManager audioMan;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        AM = GameObject.Find("AudioManager");
        audioMan = AM.GetComponent<AudioManager>();
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioMan.musicOn)
        {
            audioSource.volume = 0.2f;
        }
        else
        {
            audioSource.volume = 0;
        }
    }
}
