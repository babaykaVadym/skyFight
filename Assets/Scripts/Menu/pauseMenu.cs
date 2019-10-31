using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    public bool Pause = false;
    public bool sound = false;
    public GameObject pausePanel;

    private void Start()
    {
        if(AudioListener.volume == 0)
        {
         
            sound = false;
        }
        else
        {
            sound = true;
        }
       
    }


    // Start is called before the first frame update

    public void PauseM()
    {
        if(Pause == true)
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
            Pause = false;
            return;

        }
        if (Pause == false)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0.00001f;
            Pause = true;
            return;
        }
    }

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

public void MainMenu()
    {
        
        Application.LoadLevel("mainMenu");
    }

    public void Sound()
    {
          if(sound == true)
        {
            AudioListener.volume = 0;
            sound = false;
            return;

        }
          if(sound== false)
        {
            AudioListener.volume = 1;
            sound = true;
            return;

        }
    }
}
