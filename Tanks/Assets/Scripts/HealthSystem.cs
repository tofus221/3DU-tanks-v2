using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    // very simple healthSystem :)
    
    [SerializeField] private int _health;

    [SerializeField] private GameObject _explosion;

    public void TakeDamage()
    {
        _health--;
        if (_health == 0)
        {
            Instantiate(_explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        Debug.Log("health: " + _health);
    }
}
