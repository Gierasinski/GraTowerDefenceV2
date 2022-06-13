using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurretUIGameMaster : MonoBehaviour
{
    public GameObject ui;
    private Node target;

    //public TextMeshProUGUI fireRange;
    public TMP_InputField fireRateInput;
    public TMP_InputField fireRangeInput;
    public Slider scaleSlider;
    public Slider rSlider;
    public Slider gSlider;
    public Slider bSlider;
    public Button upgradeButton;

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();
        transform.position += new Vector3(0,1,-1);

        fireRateInput.text = target.getFireRate().ToString();
        fireRangeInput.text = target.getFireRange().ToString();
        scaleSlider.value = target.getScale().x;

        fireRateInput.onValueChanged.AddListener(delegate { ChangeFireRate(float.Parse(fireRateInput.text)); });
        fireRangeInput.onValueChanged.AddListener(delegate { ChangeFireRange(float.Parse(fireRangeInput.text)); });
        scaleSlider.onValueChanged.AddListener(delegate { ChangeScale(scaleSlider.value); });

        rSlider.onValueChanged.AddListener(delegate { ChangeColor(); });
        gSlider.onValueChanged.AddListener(delegate { ChangeColor(); });
        bSlider.onValueChanged.AddListener(delegate { ChangeColor(); });



        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }
    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
    public void ChangeFireRate(float x)
    {
        target.changeFireRate(x);
    }
    public float GetFireRate()
    {
        return target.getFireRate();
    }
    public void ChangeFireRange(float x)
    {
        target.changeFireRange(x);
    }
    public float GetFireRange()
    {
        return target.getFireRange();
    }
    public void ChangeScale(float x)
    {
        target.setScale(new Vector3(x,x,x));
    }
    public void ChangeColor()
    {
        target.setColor(new Color(rSlider.value, gSlider.value, bSlider.value));
        Debug.Log("red: " + rSlider.value);
    }
}
