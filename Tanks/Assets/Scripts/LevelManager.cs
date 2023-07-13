using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _levels;
    private int _currLevel = 0;

    private GameObject _activeLevel;

    private static int _enemyCount;

    private MusicManager _musicManager;
    
    
    void Start()
    {
        // the count is at -1 to give time to the spawners
        _enemyCount = -1;
        _musicManager = GetComponent<MusicManager>();
        ChangeLevel();
    }


    void Update()
    {
        // change lvl when enemy count drops at 0
        if (_enemyCount == 0)
        {
            // put the count at -1 (to avoid looping)
            _enemyCount--;
            _currLevel++;
            if (_currLevel == 5)
            {
                
                _musicManager.PlayMissionClear();
                SceneManager.LoadScene(0);
            }
            else
                Invoke(nameof(ChangeLevel), _musicManager.PlayRoundEnd());
            
        }       
    }

    private void ChangeLevel()
    {
        CleanUp();
        if (_activeLevel != null)
            Destroy(_activeLevel);

        // instantiate the new level
        _activeLevel = Instantiate(_levels[_currLevel], Vector3.zero, Quaternion.identity);
        
        
        // Play the music
        StartCoroutine(_musicManager.PlayRoundStart());
    }

    public static void AddEnemy()
    {
        if (_enemyCount == -1)
            _enemyCount = 1;
        else
            _enemyCount++;
    }

    public static void DeleteEnemy()
    {
        _enemyCount--;
    }

    private void CleanUp()
    {
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject bullet in bullets)
        {
            Destroy(bullet);
        }
    }
}
