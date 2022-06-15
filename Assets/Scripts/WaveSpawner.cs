using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public Transform spawnPoint;

    public TextMeshProUGUI waveText;
    public TextMeshProUGUI waveCounter;

    public float timeBetweenWaves = 2f;
    private float countdown = 2f;
    private int waveNumber = 0;


    void OnEnable()
    {
        EnemiesAlive = 0;
    }

    private void Update()
    {

        if (EnemiesAlive > 0)
            return;

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveText.text = string.Format("{0:00.00}", countdown);
        
    }
    IEnumerator SpawnWave()
    {
        if (waveNumber == waves.Length)
        {
            Debug.Log("LEVEL WON!");
            this.enabled = false;
            PlayerStats.gameWon = true;

        }
        else
        {
            Wave wave = waves[waveNumber];

            for (int i = 0; i < wave.count; i++)
            {
                SpawnEnemy(wave.enemy);
                yield return new WaitForSeconds(1f / wave.rate);
            }

            PlayerStats.Rounds++;
            waveNumber++;
            waveCounter.text = waveNumber + " WAVE";
        }


    }
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }

}
