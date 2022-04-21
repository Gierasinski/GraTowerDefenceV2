using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class OpenDoor : MonoBehaviour
{

    private Transform target;

    public Animator anim;
    public string enemyTag = "Enemy";
    public float range = 7f;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            DoorOpen(true);
        }
        else
        {
            target = null;
            DoorOpen(false);
        }


    }
    public void DoorOpen(bool bo)
    {
        anim.SetBool("EnemyNear", bo);
    }

}
