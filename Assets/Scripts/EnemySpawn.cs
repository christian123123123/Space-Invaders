using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Enemy;
    [SerializeField]
    private Transform position;

    void Start()
    {
        GameObject newEnemy = Instantiate(m_Enemy, position.position, Quaternion.identity);
    }
}
