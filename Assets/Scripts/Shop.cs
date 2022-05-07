using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public GameObject bomb;
    private GameObject bombGo;

    BuildManager buildManager;



    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Purchased");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher()
    {
        Debug.Log("Missile Launcher Purchased");
        buildManager.SelectTurretToBuild(missileLauncher);
    }
    public void SelectStandardBomb()
    {
        
        if (PlayerStats.Money >= 20)
        {
            Debug.Log("Standard Bomb Purchased");
            bombGo = (GameObject)Instantiate(bomb, transform.position, transform.rotation);
            bombGo.transform.eulerAngles = new Vector3(
                 bombGo.transform.eulerAngles.x + 90,
                 bombGo.transform.eulerAngles.y,
                 bombGo.transform.eulerAngles.z
            );
            PlayerStats.Money = PlayerStats.Money - 20;
        }
    }
}
