using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoundsSurvived : MonoBehaviour
{
    public TextMeshProUGUI roundsText;


    private void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();
    }
}
