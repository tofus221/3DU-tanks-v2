using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(_enemy, transform.position, Quaternion.identity);
        LevelManager.AddEnemy();
    }
}
