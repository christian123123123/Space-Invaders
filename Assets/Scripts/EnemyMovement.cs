using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f; // Speed of movement
    [SerializeField]
    private float boundaryLeft = -5f; // Left boundary
    [SerializeField]
    private float boundaryRight = 5f; // Right boundary
    [SerializeField]
    private float downWard = 1f;

    private Vector3 moveDirection = Vector3.right; // Initial movement direction
    private Vector3 moveDown = Vector3.down; // When reached boundary

    void Update()
    {
        MoveLineOfEnemies();
        if(Time.timeScale == 0f)
        {
            Destroy(gameObject);
        }
    }

    void MoveLineOfEnemies()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);

        // Check boundaries for the entire line
        if (transform.position.x >= boundaryRight)
        {
            transform.Translate(moveDown * downWard);
            moveDirection = Vector3.left; // Move left
        }
        else if (transform.position.x <= boundaryLeft)
        {
            transform.Translate(moveDown * downWard);
            moveDirection = Vector3.right; // Move right
        }
    }
}
