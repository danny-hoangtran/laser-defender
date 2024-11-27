using UnityEngine;
using System.Collections.Generic;

public class EnemyPathing : MonoBehaviour {
    private float velocity;
    private int waypointIndex;
    private List<Transform> waypoints;

    private void Start() {
        waypointIndex = 0;
        transform.position = waypoints[waypointIndex].position;
    }

    private void FixedUpdate() {
        Move();
    }

    private void Move() {
        if(waypointIndex <= waypoints.Count - 1) {
            float moveSpeed = velocity * Time.fixedDeltaTime;
            Vector3 targetPosition = waypoints[waypointIndex].position;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed);

            if(transform.position == targetPosition) {
                waypointIndex++;
            }
        } else {
            Destroy(gameObject);
        } 
    }

    public void SetWaypoints(List<Transform> waypoints) {
        this.waypoints = waypoints;
    }

    public void SetVelocity(float velocity) {
        this.velocity = velocity;
    }
}