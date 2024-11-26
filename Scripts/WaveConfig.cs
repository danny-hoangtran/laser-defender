using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Scriptable Object/Wave Config")]
public class WaveConfig : ScriptableObject {
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] int enemyNumber;
    [SerializeField] float spawnTimer;
    [SerializeField] float velocity;

    public GameObject GetEnemy() {
        return enemyPrefab;
    }

    public List<Transform> GetWaypoints() {
        List<Transform> waypoints = new List<Transform>();
        for(int i = 0; i < pathPrefab.transform.childCount; i++) {
            Transform waypoint = pathPrefab.transform.GetChild(i);
            waypoints.Add(waypoint);
        }
        return waypoints;
    }

    public int GetEnemyNumber() {
        return enemyNumber;
    }

    public float GetSpawnTimer() {
        return spawnTimer;
    }

    public float GetVelocity() {
        return velocity;
    }
}