using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] float minTimeBetweenShots = 0.5f;
    [SerializeField] float maxTimeBetweenShots = 2f;
    [SerializeField] GameObject enemyLaserPrefab;
    [SerializeField] int maxHealth = 300;


    private float fireTimeCounter;
    private float timeCounter;

    void Start() {
        timeCounter = 0;
        fireTimeCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);    
    }

    // Update is called once per frame
    void Update() {
        Fire();
    }

    private void Fire() {
        timeCounter = timeCounter + Time.deltaTime;
        if(timeCounter >= fireTimeCounter) {
            GameObject laserObject = Instantiate(enemyLaserPrefab, transform.position, Quaternion.identity);
            laserObject.transform.position = new Vector2(laserObject.transform.position.x, laserObject.transform.position.y - 0.8f);
            fireTimeCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
            timeCounter = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        damageDealer.Hit();
        maxHealth -= damageDealer.GetDamage();

        if(maxHealth <= 0) {
            Destroy(gameObject);
        }
    }
}
