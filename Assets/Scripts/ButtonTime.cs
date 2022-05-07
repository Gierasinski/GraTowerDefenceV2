using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTime : MonoBehaviour
{
    private bool pause = false;

    public TimeManager timeManager;
    public void toggle()
    {
        pause = !pause;

        if (pause)
        {
            timeManager.SetTimeScale(0f);
        }
        else
        {
            timeManager.SetTimeScale(1f);
        }
    }
}
