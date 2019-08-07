using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActiveSong : MonoBehaviourSingleton<ActiveSong>
{
    public bool isSongActive;
    public AudioSource audioSource;
    public string[] activeSongScenes;
    public bool musicOn;
    // Start is called before the first frame update
    void Start()
    {
        musicOn = true;
        audioSource = GetComponent<AudioSource>();
        SetMenuSong();
        CheckNextScene(SceneManager.GetActiveScene().name);
    }

    public void CheckNextScene(string sceneName)
    {
        bool canStopSong = true;

        for (int i = 0; i < activeSongScenes.Length; i++)
        {
            if (activeSongScenes[i] == sceneName)
            {
                canStopSong = false;
            }
        }

        if(canStopSong)
        {
            audioSource.Stop();
            isSongActive = false;
        }
        else
        {
            if(!isSongActive)
            {
                audioSource.Play();
                isSongActive = true;
            }
        }
    }

    public void SetMenuSong()
    {
        audioSource.clip = AudioManager.Get().songs["SongMenu"];
    }

    public void ToggleMusic()
    {
        musicOn = !musicOn;

        if (musicOn)
            audioSource.volume = 0.4f;
        else
            audioSource.volume = 0;

    }
}
