using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Prefab;
    [SerializeField]
    private Transform m_Transform;
    void Start()
    {
        GameObject newEnemy = Instantiate(m_Prefab, m_Transform.position, Quaternion.identity);
    }
}
