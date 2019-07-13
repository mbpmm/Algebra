using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviourSingleton<Test>
{
    private bool test;
    private bool test2;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Get().PlaySound("SongMenu");
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name=="Level1" || SceneManager.GetActiveScene().name == "Level1")
        {
            test = true;
        }

        if (test&&!test2)
        {
            AudioManager.Get().ToggleSound();
            test = false;
            test2 = true;
        }
        
    }
}
