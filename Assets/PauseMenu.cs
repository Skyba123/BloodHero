using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public bool PauseGame;
    public GameObject pauseGameMenu;
    
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider ambientSlider;
    [SerializeField] private Slider objectsSlider;
    [SerializeField] private Slider SFXSlider;

    void Start()
    {
        if (PlayerPrefs.HasKey("masterVolume") || PlayerPrefs.HasKey("ambientVolume") || PlayerPrefs.HasKey("objectsVolume") || PlayerPrefs.HasKey("SFXVolume") )
        {
            LoadVolume();
        }
        else SetMasterVolume(); SetAmbientVolume(); SetObjectsVolume(); SetSFXVolume();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!PauseGame)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }
    public void Resume()
    {
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1.0f;
        LoadVolume();
        PauseGame = false;
    }
    public void Pause()
    {
        pauseGameMenu.SetActive(true);
        Time.timeScale = 0f;
        myMixer.SetFloat("master", -80);
        myMixer.SetFloat("ambient", -80);
        myMixer.SetFloat("objects", -80);
        myMixer.SetFloat("sfx", -80);
        PauseGame = true;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }

    public void SetMasterVolume()
    {
        float volume = masterSlider.value;
        myMixer.SetFloat("master", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("masterVolume", volume);
    }
    public void SetAmbientVolume()
    {
        float volume = ambientSlider.value;
        myMixer.SetFloat("ambient", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("ambientVolume", volume);
    }
    public void SetObjectsVolume()
    {
        float volume = objectsSlider.value;
        myMixer.SetFloat("objects", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("objectsVolume", volume);
    }
    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        myMixer.SetFloat("sfx", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    private void LoadVolume()
    {
        masterSlider.value = PlayerPrefs.GetFloat("masterVolume");
        ambientSlider.value = PlayerPrefs.GetFloat("ambientVolume");
        objectsSlider.value = PlayerPrefs.GetFloat("objectsVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        
        SetMasterVolume();
        SetAmbientVolume();
        SetObjectsVolume();
        SetSFXVolume();
    }

}
