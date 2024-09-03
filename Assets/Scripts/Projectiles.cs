using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float shootCooldown = 1f;
    [SerializeField]
    private AudioSource audioSource;
    private float timeSinceLastShot = 0f;
    private bool isSpacePressed;
    
    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && timeSinceLastShot >= shootCooldown)
        {
            Shoot();
            audioSource.Play();
        }
    }

    private void Shoot()
    {
        Instantiate(projectile, player.position, Quaternion.identity);
        timeSinceLastShot = 0f;
    }
}
