using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaticEnemyScript : MonoBehaviour
{
    public float startSpeed = 30f;
    public float startHealth = 100f;
    public int value = 5;

    [HideInInspector]
    public float speed;
    [HideInInspector]
    public float health;



    public GameObject deathEffect;

    [Header("Unity Stuff")]
    public Image healthBar;

    void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }

    public void TakeDamge(int amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.Money += value;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);

        WaveSpawner.EnemiesAlive--;

        Destroy(effect, 5f);
    }


}
