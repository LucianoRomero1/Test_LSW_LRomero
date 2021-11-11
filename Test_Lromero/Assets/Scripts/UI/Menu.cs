using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject soundOn;
    public GameObject soundOff;
    public GameObject soundManager;

    private bool flag = true;
    public void SoundOff()
    {
        soundManager.GetComponent<AudioSource>().enabled = false;
        soundOff.SetActive(true);
        soundOn.SetActive(false);
        flag = false;
    }

    public void SoundOn()
    {
        soundManager.GetComponent<AudioSource>().enabled = true;
        soundOn.SetActive(true);
        soundOff.SetActive(false);
        flag = true;
    }

    public void CheckSound()
    {
        if (flag)
        {
            SoundOff();
        }
        else
        {
            SoundOn();
        }
    }

    public void Gameplay()
    {
        SceneManager.LoadScene("Gameplay");
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
