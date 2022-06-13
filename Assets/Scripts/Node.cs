using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;


   // [Header("Optional")]
    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if(turret != null)
        {
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetMouseButtonDown(0))
            {
                buildManager.SelectNode(this, true);
            }else
            {
                buildManager.SelectNode(this, false);
            }
                
            return;
        }
        if (!buildManager.CanBuild)
            return;
        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money!");
            return;
        }

        PlayerStats.Money -= blueprint.cost;
        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        Debug.Log("Turret build! Money left: " + PlayerStats.Money);
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade!");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;
        //Destroy old turret
        Destroy(turret);

        //Build upgraded turret
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;
        Debug.Log("Turret upgraded ");
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();

        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(turret);
        turretBlueprint = null;
        isUpgraded = false;

    }

        void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;
        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        } else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
    public void changeFireRate(float x)
    {
        turret.GetComponent<Turret>().changeFireRate(x);
    }
    public float getFireRate()
    {
        return turret.GetComponent<Turret>().getFireRate();
    }
    public void changeFireRange(float x)
    {
        turret.GetComponent<Turret>().changeFireRange(x);
    }
    public float getFireRange()
    {
        return turret.GetComponent<Turret>().getFireRange();
    }
    public Vector3 getScale()
    {
        return turret.GetComponent<Turret>().getScale();
    }
    public void setScale(Vector3 v)
    {
        turret.GetComponent<Turret>().setScale(v);
    }
    public void setColor(Color c)
    {
        turret.GetComponent<Turret>().setColor(c);
    }
}
