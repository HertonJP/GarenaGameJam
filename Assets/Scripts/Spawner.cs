using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;

    [SerializeField] private int baseEnemies = 3;
    [SerializeField] private float enemiesPerSecond = 1f;
    [SerializeField] private float timeBetweenWaves = 1f;
    [SerializeField] private float difficultyScalingFactor = 0.75f;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private int wavesUntilStatIncrease = 5;
    [SerializeField] private GameObject talentPanel;
    [SerializeField] private PlayerStats player;
    public int wavesCompleted = 0;
    private TextMeshProUGUI waveText;

    public static UnityEvent onEnemyDestroy = new UnityEvent();

    public int currentWave = 1;
    private float timeSinceLastSpawn;
    public int enemiesAlive;
    public int enemiesLeftToSpawn;
    private bool isSpawning = false;

    private void Awake()
    {
        onEnemyDestroy.AddListener(enemyDestroyed);
    }

    private void enemyDestroyed()
    {
        Debug.Log("enemy berkurang");
        enemiesAlive--;
    }

    private void Start()
    {
        talentPanel.SetActive(false);
        waveText = GameObject.Find("WaveText").GetComponent<TextMeshProUGUI>();
        waveText.text = "Current Wave: " + currentWave.ToString();
        StartCoroutine(StartWave());
    }

    private void Update()
    {
        if (!isSpawning)
        {
            return;
        }
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeftToSpawn > 0)
        {
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
        }
        if (enemiesLeftToSpawn == 0 && enemiesAlive <= 0)
        {
            EndWave();
        }
        waveText.text = "Current Wave: " + currentWave.ToString();
    }

    private void EndWave()
    {
        if(currentWave % 3 == 0)
        {
            player.playerHP = player.playerMaxHP;
        }
        if(currentWave == 3 || currentWave == 6|| currentWave == 9 )
        {
            
            talentPanel.SetActive(true);
            Time.timeScale = 0;
        }
        
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        currentWave++;
        if (wavesCompleted >= wavesUntilStatIncrease)
        {
            for (int i = 0; i < enemyPrefabs.Length; i++)
            {
                Enemy enemyPrefabScript = enemyPrefabs[i].GetComponent<Enemy>();
                enemyPrefabScript.enemyHP += 10;
               // enemyPrefabScript.attackSpeed += 0.5f;
            }

            wavesCompleted = 0;
        }
        StartCoroutine(StartWave());
    }

    private void SpawnEnemy()
    {
        int index = Random.Range(0, enemyPrefabs.Length);
        GameObject prefabToSpawn = enemyPrefabs[index];

        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        Instantiate(prefabToSpawn, randomSpawnPoint.position, Quaternion.identity);
    }



    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
    }

    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScalingFactor));
    }
}