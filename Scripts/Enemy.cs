using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Enemy : MonoBehaviour {
    [SerializeField] float minTimeBetweenShots = 0.5f;
    [SerializeField] float maxTimeBetweenShots = 2f;
    [SerializeField] GameObject enemyLaserPrefab;
    [SerializeField] GameObject explosionEffectPrefab;
    [SerializeField] int maxHealth = 300;
  
    private float fireRate;
    private int enemyDestroyPoints = 50;
    private EnemyAudio enemyAudio;

    void Start() {
        StartCoroutine(Fire());
        enemyAudio = GetComponent<EnemyAudio>();
    }

    IEnumerator Fire() {
        while(true) {
            fireRate = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
            yield return new WaitForSeconds(fireRate);
            GameObject laserObject = Instantiate(enemyLaserPrefab, transform.position, Quaternion.identity);
            enemyAudio.PlayShootSFX();
            laserObject.transform.position = new Vector2(laserObject.transform.position.x, laserObject.transform.position.y - 0.8f);
        }    
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Laser") {
            DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
            damageDealer.Hit();
            maxHealth -= damageDealer.GetDamage();
        }

        if(maxHealth <= 0) {
            int point = GameSession.GetInstance().GetPoint();
            point += enemyDestroyPoints;
            GameSession.GetInstance().SetPoint(point);
            StartCoroutine(OnDestroyObject());
        }
    }

    IEnumerator OnDestroyObject() {
        yield return new WaitForSeconds(0.2f);
        enemyAudio.PlayDestroySFX();
        GameObject explosionObject = Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
        Destroy(explosionObject, .3f);
        Destroy(gameObject);
    }
}
