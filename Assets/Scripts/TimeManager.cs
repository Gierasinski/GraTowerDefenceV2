using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Slider _slider;
    public TextMeshProUGUI text;

    public GameObject pauseIMG;
    public GameObject startIMG;
    public void SetTimeScale(float speed)
    {
        Time.timeScale = speed;
        text.text = "SPEED X: " + speed;
        _slider.value = speed;
        if(speed > 0)
        {
            pauseIMG.SetActive(true);
            startIMG.SetActive(false);
        }else
        {
            pauseIMG.SetActive(false);
            startIMG.SetActive(true);
        }

        //Time.fixedDeltaTime = Time.timeScale * 0.02f;   
    }
}
