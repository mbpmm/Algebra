using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicToggle : MonoBehaviour
{
    public GameObject AM;
    private AudioManager audioMan;
    public GameObject menuSong;
    private ActiveSong actSong;
    public Button soundButton;
    //Start is called before the first frame update
    void Start()
    {
        AM = GameObject.Find("AudioManager");
        audioMan = AM.GetComponent<AudioManager>();
        menuSong = GameObject.Find("Menu Song");
        actSong = menuSong.GetComponent<ActiveSong>();
    }


    public void ToggleMusic()
    {
        audioMan.ToggleMusic();
        actSong.ToggleMusic();
    }
}
