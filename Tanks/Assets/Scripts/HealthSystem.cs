using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            // kinda weird to do this here but hey it works
            if (CompareTag("Enemy"))
                LevelManager.DeleteEnemy();
            
            Instantiate(_explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            
            // change scene if the player is dead
            if (CompareTag("Player"))
                SceneManager.LoadScene(0);
        }
        Debug.Log("health: " + _health);
    }
}
