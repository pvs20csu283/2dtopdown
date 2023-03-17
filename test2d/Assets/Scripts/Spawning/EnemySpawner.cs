using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public List<EnemyGroup> enemyGroups; //a list of group of enemies to be spawned
        public int waveQuota; //total no. of enemies to spawn in the game.
        public float spawnInterval;//at which interval to spawn the enemies
        public float spawnCount;//no. of enemies already spawned in the game
    }

    [System.Serializable]
    public class EnemyGroup
    {
        public string enemyName;
        public int enemyCount; //no. of enemies to spawn
        public int spawnCount;//no. of enemies in the scene
        public GameObject enemyPrefab;
    }

    public List<Wave> waves; //a list of all the waves in the game
    public int currentWaveCount; // the index of the current wave 

    [Header("Spawner Attributes")]
    float spawnTimer; //time use to determine when to spawn the next enemy
    public int enemiesAlive;
    public int maxEnemiesAllowed;
    public bool maxEnemiesReached = false;
    public float waveInterval; //the interval between each wave

    [Header("Spawn Positions")]
    public List<Transform> relativeSpawnPoints;

    Transform player;


    void Start()
    {
        player = FindObjectOfType<PlayerStats>().transform;
        CalculateWaveQuota();

    }

    // Update is called once per frame
    void Update()
    {
        if (currentWaveCount < waves.Count && waves[currentWaveCount].spawnCount == 0)
        {
            StartCoroutine(BeginNextWave());
        }

        spawnTimer += Time.deltaTime;

        //check if it's time to spawn the next enemy
        if (spawnTimer >= waves[currentWaveCount].spawnInterval)
        {
            spawnTimer = 0f;
            SpawnEnemies();
        }
    }

    IEnumerator BeginNextWave()
    {
        //wave for  waveInterval seconds  before starting  the next wave
        yield return new WaitForSeconds(waveInterval);

        //if there are more waves to start after the current wave, move on to the next one
        if (currentWaveCount < waves.Count - 1)
        {
            currentWaveCount++;
            CalculateWaveQuota();
        }
    }

    void CalculateWaveQuota()
    {
        int currentWaveQuota = 0;
        foreach (var enemyGroup in waves[currentWaveCount].enemyGroups)
        {
            currentWaveQuota += enemyGroup.enemyCount;
        }

        waves[currentWaveCount].waveQuota = currentWaveQuota;

    }

    void SpawnEnemies()
    {
        //to check if the minimum number of enemies in the wave have been spawned
        if (waves[currentWaveCount].spawnCount < waves[currentWaveCount].waveQuota && !maxEnemiesReached)
        {
            //spawn each type of enemy until the quota is fileed
            foreach (var enemyGroup in waves[currentWaveCount].enemyGroups)
            {
                //check if the min. no. of enemies of this type have been spawned
                if (enemyGroup.spawnCount < enemyGroup.enemyCount)
                {
                    if (enemiesAlive >= maxEnemiesAllowed)
                    {
                        maxEnemiesReached = true;
                        return;
                    }

                    Instantiate(enemyGroup.enemyPrefab, player.position + relativeSpawnPoints[Random.Range(0, relativeSpawnPoints.Count)].position, Quaternion.identity);

                   // Vector2 spawnPosition = new Vector2(player.transform.position.x + Random.Range(-10f, 10f), player.transform.position.y + Random.Range(-10f, 10f));
                   // Instantiate(enemyGroup.enemyPrefab, spawnPosition, Quaternion.identity);

                    enemyGroup.spawnCount++;
                    waves[currentWaveCount].spawnCount++;
                    enemiesAlive++;
                }
            }

        }
        if (enemiesAlive < maxEnemiesAllowed)
        {
          maxEnemiesReached = false;
        }

    }

    public void OnEnemyKilled()
    {
        enemiesAlive--;
    }
    
}
