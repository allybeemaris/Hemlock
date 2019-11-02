using UnityEngine;

public class Movement : MonoBehaviour
{
    public MovementController controller;
    public int speed = 10;
    [Range(-1, 1)] public int direction;
    public bool patrol = false;
    public int patrolWidth = 0;

    private float currentPatrolPoint;

    void Start() {
        currentPatrolPoint = patrolWidth / 2;
    }

    void FixedUpdate () {
        // Movement
        var moveDistance = direction * speed * Time.fixedDeltaTime;
        controller.Move(moveDistance, false, false);

        if (patrol) {
            currentPatrolPoint += moveDistance;

            if (currentPatrolPoint < 0) {
                direction = 1;
            }
            else if (currentPatrolPoint > patrolWidth) {
                direction = -1;
            }
        }
    }
}
