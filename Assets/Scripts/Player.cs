using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float speed = 5f;
    private bool dIsPressed;
    private bool aIsPressed;

    public bool gameIsOver;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            dIsPressed = true;
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            aIsPressed = true;
        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            dIsPressed = false;
        }
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            aIsPressed = false;
        }
    }

    private void FixedUpdate()
    {
        if (dIsPressed)
        {
            rb.velocity = Vector2.right * speed;
        }
        else if (aIsPressed)
        {
            rb.velocity = Vector2.left * speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Time.timeScale = 0f;
        }
    }
}
