using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UFOMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;

    private Vector3 moveDown = Vector3.down;
    private Vector3 moveDirection = Vector3.right;

    private float boundaryRight = 8f;
    private float boundaryLeft = -8f;

    private void Update()
    {
        MoveUFO();
    }

    void MoveUFO()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);

        // Check boundaries for the entire line
        if (transform.position.x >= boundaryRight)
        {
            moveDirection = Vector3.left; // Move left
        }
        else if (transform.position.x <= boundaryLeft)
        {
            moveDirection = Vector3.right; // Move right
        }
    }
}
