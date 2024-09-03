using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private float shootInterval = 2f;

    private List<Transform> enemyShips = new List<Transform>();
    private float timeSinceLastShot = 0f;

    private void Start()
    {
        foreach(Transform child in transform)
        {
            enemyShips.Add(child);
        }
    }

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        if(timeSinceLastShot >= shootInterval)
        {
            ShootRandomShip();
            timeSinceLastShot = 0f;
        }
    }

    private void ShootRandomShip()
    {
        if(enemyShips.Count > 0)
        {
            int randomIndex = Random.Range(0,enemyShips.Count);
            Transform randomShip = enemyShips[randomIndex];
            if(randomShip != null)
            {
                Instantiate(projectile, randomShip.position, Quaternion.identity);
            }

        }
    }
}
