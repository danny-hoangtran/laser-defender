using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] float velocity = 6f;
    [SerializeField] float boundaryPadding = 5f;
    [SerializeField] float fireRate;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] int maxHealth = 400;

    private float minHorizontalBoundary, maxHorizontalBoundary, minVerticalBoundary, maxVerticalBoundary;
    private Coroutine fireCoroutine;
    private bool fireEnabled;
    private PlayerAudio playerAudio;

    public void Start() {
        fireEnabled = true;
        SetBoundaries();
        playerAudio = GetComponent<PlayerAudio>();
    }

    public void FixedUpdate() {
        Move();
        Fire();
    }

    private void Move() {
        float horizontalMoveSpeed = Input.GetAxis("Horizontal") * velocity * Time.fixedDeltaTime;
        float verticalMoveSpeed = Input.GetAxis("Vertical") * velocity * Time.fixedDeltaTime;
        Vector2 currentPosition = transform.position;
        Vector2 updatePosition = new Vector2(currentPosition.x + horizontalMoveSpeed, currentPosition.y + verticalMoveSpeed);
        updatePosition.x = Mathf.Clamp(updatePosition.x, minHorizontalBoundary, maxHorizontalBoundary);
        updatePosition.y = Mathf.Clamp(updatePosition.y, minVerticalBoundary, maxVerticalBoundary);
        transform.position = updatePosition;
    }

    private void SetBoundaries() {
        Camera mainCamera = Camera.main;
        minHorizontalBoundary = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + boundaryPadding;
        maxHorizontalBoundary = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - boundaryPadding;
        minVerticalBoundary = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + boundaryPadding;
        maxVerticalBoundary = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - boundaryPadding;
    }

    private void Fire() {
        if (Input.GetKey(KeyCode.Space) && fireEnabled) {
            if (fireCoroutine == null) {
                fireCoroutine = StartCoroutine(FireCoroutine());
            }
        }
    }

    IEnumerator FireCoroutine() {
        while (Input.GetKey(KeyCode.Space)) { 
            if (fireEnabled) { 
                GameObject laserObject = Instantiate(laserPrefab, transform.position, Quaternion.identity);
                playerAudio.PlayShootSFX();
                laserObject.transform.position = new Vector2(laserObject.transform.position.x, laserObject.transform.position.y + 0.8f); 
                fireEnabled = false; 
                yield return new WaitForSeconds(fireRate); 
                fireEnabled = true; 
            } else { 
                yield return null; 
            } 
        }
        fireCoroutine = null;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        maxHealth -= damageDealer.GetDamage();

        if(collision.gameObject.tag == "Laser") {
            damageDealer.Hit();
        }

        if(maxHealth <= 0) {
            playerAudio.PlayDestroySFX();
            Destroy(gameObject, .2f);
            SceneLoader.GetInstance().LoadNextScene();
        }
    }

    public float GetHealth() {
        return maxHealth;
    }
}