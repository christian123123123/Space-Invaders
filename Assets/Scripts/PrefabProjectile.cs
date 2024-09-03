using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabProjectile : MonoBehaviour
{
    [SerializeField]
    private AudioClip hitSound; // The sound clip to play on hit
    private Rigidbody2D rb;
    public float speed = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * speed;
    }

    private void OnEnable()
    {
        if (rb != null)
        {
            rb.velocity = Vector2.up * speed;
        }
    }

    private void Update()
    {
        if (transform.position.y >= 6f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            // Play the hit sound using a temporary audio source
            PlayHitSound();

            // Handle score addition
            Logic logic = FindObjectOfType<Logic>();
            logic.AddScore(collision.gameObject.layer);

            // Destroy the enemy and the projectile
            Destroy(collision.collider.gameObject);
            Destroy(gameObject);
        }
    }

    private void PlayHitSound()
    {
        // Create a temporary GameObject to play the sound
        GameObject tempAudio = new GameObject("TempAudio");
        AudioSource audioSource = tempAudio.AddComponent<AudioSource>();
        audioSource.clip = hitSound;
        audioSource.Play();

        // Destroy the temporary GameObject after the clip has finished playing
        Destroy(tempAudio, hitSound.length);
    }
}
