using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    private static AudioManager instance;
    [Header("Sound Options")]
    public bool soundOn = true;
    public bool musicOn = true;
    public Dictionary<string, AudioClip> audios=new Dictionary<string, AudioClip>();
    public Dictionary<string, AudioClip> songs = new Dictionary<string, AudioClip>();
    public SoundZ[] sfxs;
    public SoundZ[] musics;

    [System.Serializable]
    public class SoundZ
    {
        public string soundName;
        public AudioClip clip;
    }
    public enum SoundType
    {
        CommonButton,
        Help,
        Etc
    }

    public static AudioManager Get()
    {
        return instance;
    }

    // Use this for initialization
    private void Start()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        instance = this;

        PlayerProfile.Get().CheckPlayerPrefs();
        soundOn = PlayerProfile.Get().GetSoundOn();
        musicOn = PlayerProfile.Get().GetMusicOn();
        audioSource = GetComponent<AudioSource>();

        foreach (SoundZ ac in sfxs)
        {
            audios.Add(ac.soundName, ac.clip);
        }

        foreach (SoundZ ac in musics)
        {
            songs.Add(ac.soundName, ac.clip);
        }
    }

    public void PlaySound(string st)
    {
        if (!soundOn)
            return;
        if (audios.ContainsKey(st)) //usando diccionarios 
        {
            AudioSource.PlayClipAtPoint(audios[st], new Vector3(14.24f, 4.82f, 0), 1.0f);
        }
    }

    public void PlayMusic(string st)
    {
        audioSource.clip = songs[st];
        if (!musicOn)
            return;

        audioSource.Play();
    }

    public void ToggleSound()
    {
        soundOn = !soundOn;

        if (soundOn)
            PlaySound(SoundType.CommonButton.ToString());

        //PlayerProfile.Get().SaveSoundOptions(this);
    }

    public void ToggleMusic()
    {
        ToggleSound();
        musicOn = !musicOn;

        if (musicOn)
        {
            if (SceneManager.GetActiveScene().name != "Menu")
            {
                audioSource.Play();
            }
            
            audioSource.volume = 0.4f;
        }
        else
        {
            audioSource.Stop();
            audioSource.volume = 0;

        }

        //PlayerProfile.Get().SaveSoundOptions(this);
    }
}

