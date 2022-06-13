using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;


    [Header("Attributes")]

    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    private Renderer turretRenderer;
    private Color newColor;


    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <=range)
        {
            target = nearestEnemy.transform;
        } else
        {
            target = null;
        }





    }
    private void Update()
    {
        if(target == null)
        {
            return;
        }


        //Target lock
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime*turnSpeed).eulerAngles;

        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if(fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
        
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }


  

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void changeFireRate(float x)
    {
        this.fireRate = x;

    }
    public float getFireRate()
    {
        return this.fireRate; 
    }
    public void changeFireRange(float x)
    {
        this.range = x;

    }
    public float getFireRange()
    {
        return this.range;
    }
    public Vector3 getScale()
    {
        return this.transform.localScale;
    }
    public void setScale(Vector3 v)
    {
        this.transform.localScale = v;
    }

    public void setColor(Color c)
    {
        foreach (var rend in GetComponentsInChildren<Renderer>(true))
        {
            rend.material.color = c;
        }

    }
}
