using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMana : MonoBehaviour
{
    public GameObject settingsPanel;
    public void PlayGame()
    {
        SceneManager.LoadScene("Scenka");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void SettingsPanel()
    {
        settingsPanel.SetActive(true);
    }
    public void Exit()
    {
        settingsPanel.SetActive(false);
    }
}
