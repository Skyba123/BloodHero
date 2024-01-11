using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool PauseGame;
    public GameObject pauseGameMenu;
    public GameObject ambienMusic;
    public GameObject Campfire1;
    public GameObject Campfire2;
    public GameObject Campfire3;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseGame)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1.0f;
        ambienMusic.SetActive(true);
        Campfire1.GetComponent<AudioSource>().Play();
        Campfire2.GetComponent<AudioSource>().Play();
        Campfire3.GetComponent<AudioSource>().Play();
        PauseGame = false;
    }
    public void Pause()
    {
        pauseGameMenu.SetActive(true);
        Time.timeScale = 0f;
        ambienMusic.SetActive(false);
        Campfire1.GetComponent<AudioSource>().Stop();
        Campfire2.GetComponent<AudioSource>().Stop();
        Campfire3.GetComponent<AudioSource>().Stop();
        PauseGame = true;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }

}
