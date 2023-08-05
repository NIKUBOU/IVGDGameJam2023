using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*[System.Serializable]
public class WaveConfiguration
{
    public float delayBeforeWave;
    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoints;
    public int[] enemyCounts;
    public float delayBetweenSpawns;
}*/

[System.Serializable]
public class WaveConfiguration
{
    public float delayBeforeWave;
    public List<EnemySpawnData> enemySpawnData = new List<EnemySpawnData>();
}

[System.Serializable]
public class EnemySpawnData
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public int enemyCount;
    public float delayBetweenSpawns;
}



public class WaveManager : MonoBehaviour
{
    public List<WaveConfiguration> waveConfigurations = new List<WaveConfiguration>();
    private int currentWaveIndex = 0;
    private bool isWaveInProgress = false;

    private void Start()
    {
        // Start the first wave when the script starts
        StartWave();
    }

    private void Update()
    {
        // Check if the current wave has been completed and if more waves are available
        if (!isWaveInProgress && currentWaveIndex < waveConfigurations.Count)
        {
            StartCoroutine(StartNextWaveWithDelay());
        }
    }

    private IEnumerator StartNextWaveWithDelay()
    {
        // Delay before starting the next wave
        yield return new WaitForSeconds(waveConfigurations[currentWaveIndex].delayBeforeWave);
        StartWave();
    }

    private void StartWave()
    {
        // Check if all waves have been completed
        if (currentWaveIndex >= waveConfigurations.Count)
        {
            Debug.Log("All waves completed!");
            return;
        }

        // Get the current wave configuration
        WaveConfiguration waveConfig = waveConfigurations[currentWaveIndex];

        // Start spawning enemies for the current wave
        StartCoroutine(SpawnEnemies(waveConfig));
        currentWaveIndex++;
    }

    private IEnumerator SpawnEnemies(WaveConfiguration waveConfig)
    {
        isWaveInProgress = true;

        // Loop through each enemy spawn data in the current wave
        foreach (var enemyData in waveConfig.enemySpawnData)
        {
            // Spawn the specified number of enemies with a delay between spawns
            for (int j = 0; j < enemyData.enemyCount; j++)
            {
                GameObject enemyPrefab = enemyData.enemyPrefab;
                Transform spawnPoint = enemyData.spawnPoint;

                Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
                yield return new WaitForSeconds(enemyData.delayBetweenSpawns);
            }
        }

        isWaveInProgress = false;
    }
}
