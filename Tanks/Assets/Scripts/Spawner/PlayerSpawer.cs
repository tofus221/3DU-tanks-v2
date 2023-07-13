using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawer : MonoBehaviour
{
    [SerializeField] private GameObject _Player;
    
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(_Player, transform);
    }
}
