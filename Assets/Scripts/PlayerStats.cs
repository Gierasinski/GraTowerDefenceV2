using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;

    public static int Lives;
    public int startLives = 20;

    public static int Rounds;

    public static bool gameWon;
    public bool gameWonBool = false;

    private void Start()
    {

        Money = startMoney;
        Lives = startLives;

        gameWon = gameWonBool;

        Rounds = 0;
     }

}
