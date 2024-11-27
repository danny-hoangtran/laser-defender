using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] bool isLoop = false;

    private int waveIndex;
    private WaveConfig currentWave;

    private void Start() {
        waveIndex = 0;
        currentWave = waveConfigs[waveIndex];
        StartCoroutine(SpawnAllWaves());
    }

    IEnumerator SpawnAllWaves() {
        do {
            yield return StartCoroutine(SpawnEnemies(currentWave));
            waveIndex++;
            if (waveIndex == waveConfigs.Count) { waveIndex = 0; }
            currentWave = waveConfigs[waveIndex];
        } while (isLoop);
       
    }

    IEnumerator SpawnEnemies(WaveConfig waveConfig) {
        GameObject enemyPrefab = waveConfig.GetEnemy();
        int enemyNumber = waveConfig.GetEnemyNumber();
        List<Transform> waypoints = waveConfig.GetWaypoints();
        float velocity = waveConfig.GetVelocity();
        float spawnTimer = waveConfig.GetSpawnTimer();

        for (int i = 0; i < enemyNumber; i++) {
            GameObject enemyShip = Instantiate(enemyPrefab, waypoints[0].transform.position, Quaternion.identity);
            enemyShip.GetComponent<EnemyPathing>().SetWaypoints(waypoints);
            enemyShip.GetComponent<EnemyPathing>().SetVelocity(velocity);
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}