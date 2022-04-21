using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI roundsText;
    public string levelToLoad = "MainMenu";

    public SceneFader sceneFader;

    private void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();
    }
    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        sceneFader.FadeTo(levelToLoad);
    }
}
