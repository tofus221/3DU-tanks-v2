using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _levels;
    private int _currLevel = 0;
    
    static private int _enemyCount;
    
    
    void Start()
    {
        ChangeLevel();
    }


    void Update()
    {
        // change lvl when enemy count drops at 0
        if (_enemyCount == 0)
        {
            _currLevel++;
            ChangeLevel();
        }       
    }

    private void ChangeLevel()
    {
        // instantiate the new level and put the count at -1 (to avoid changing lvl directly)
        Instantiate(_levels[_currLevel], Vector3.zero, Quaternion.identity);
        _enemyCount = -1;
    }

    public static void AddEnemy()
    {
        if (_enemyCount == -1)
            _enemyCount = 1;
        else
            _enemyCount++;
    }
}
