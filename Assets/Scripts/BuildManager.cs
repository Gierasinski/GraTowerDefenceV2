using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;


    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("BuilderManager exists");
            return;
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;

    public GameObject buildEffect;
    public GameObject sellEffect;

    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    public TurretUI turretUI;
    public TurretUIGameMaster turretUIGameMaster;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void SelectNode (Node node, bool gameMaster)
    {

        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;
        if (!gameMaster)
        {
            turretUI.SetTarget(node);
        }else
        {
            turretUIGameMaster.SetTarget(node);
        }
        
    }
    public void DeselectNode()
    {
        selectedNode = null;
        turretUI.Hide();
        turretUIGameMaster.Hide();
    }
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }
    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }

}
