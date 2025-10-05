using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{





    public GameObject panel;

    public static Boolean gamePaused;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void pause()
    {
        gamePaused = true;
        Time.timeScale = 0;
        panel.SetActive(true);

    }

    public void resume()
    {
        gamePaused = false;
        Time.timeScale = 1;
        panel.SetActive(false);
    }

    public void salirMenu()
    {
        Time.timeScale = 1;
        panel.SetActive(false);
    }

    public void irMenuPrincipal()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void activarDesactivarAudio()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}
