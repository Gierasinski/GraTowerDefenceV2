using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject ui;
    public string levelToLoad = "MainMenu";

    public SceneFader sceneFader;
    public TimeManager timeManager;

    public GameObject hud;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        hud.SetActive(ui.activeSelf);
        ui.SetActive(!ui.activeSelf);
        if (ui.activeSelf)
        {
            //Time.timeScale = 0f;
            timeManager.SetTimeScale(0f);
        }
        else
        {
            //Time.timeScale = 1f;
            timeManager.SetTimeScale(1f);
        }
    }
    public void Retry()
    {
        Toggle();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Toggle();
        sceneFader.FadeTo(levelToLoad);
    }
}
