using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "MainLevel";
    public GameObject optionsCanvas;
    public GameObject menuCanvas;

    public GameObject enemy;
    public Transform waypoint;

    public SceneFader sceneFader;

    public void Play()
    {
        sceneFader.FadeTo(levelToLoad);
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        Instantiate(enemy, waypoint.position, waypoint.rotation);
    }
    public void Options()
    {
        optionsCanvas.SetActive(true);
        menuCanvas.SetActive(false);
    }
    public void Return()
    {
        optionsCanvas.SetActive(false);
        menuCanvas.SetActive(true);
    }

    public void Quit()
    {
        Debug.Log("Exiting...");
        Application.Quit();
    }
}
