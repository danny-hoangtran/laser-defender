using UnityEngine;

public class Laser : MonoBehaviour {
    [SerializeField] float projectileVelocity = 15f;

    private void FixedUpdate() {
        Move();
    }

    private void Move() {
        Vector2 currentPosition = transform.position;
        float moveSpeed = projectileVelocity * Time.fixedDeltaTime;
        Vector2 updatePosition = new Vector2(currentPosition.x, currentPosition.y + moveSpeed);
        transform.position = updatePosition;
    }

     private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Shredder") {
            Destroy(gameObject);
        }   
    }
}