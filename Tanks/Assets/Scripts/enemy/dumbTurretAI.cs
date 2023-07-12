using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class dumbTurretAI : MonoBehaviour
{
    [SerializeField] private Transform _tower;
    [SerializeField] private Transform _baseCanon;
    [SerializeField] private Transform _endCanon;
    
    [Space]
    
    [SerializeField] private float _rotateSpeed;
    private int _rotationDirection = 1;
    
    [Space]
    
    [SerializeField] private float _projectileSpeed;
    [SerializeField] private GameObject _bullet;
    private GameObject _currentAmmo;


    private void Start()
    {
        Invoke(nameof(ChangeDirection), Random.Range(2, 5));
    }

    // Update is called once per frame
    void Update()
    {
        _tower.RotateAround(_tower.position, Vector3.up, _rotateSpeed * _rotationDirection * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        // fires bullet when it sees the player
        if (Physics.Raycast(_tower.position, _endCanon.position - _baseCanon.position, 30, LayerMask.GetMask("Player"))
            && CanFire())
        {
            _currentAmmo = Instantiate(_bullet, _endCanon.position, _tower.rotation * Quaternion.Euler(90, 0, 0));
            Rigidbody rgbAmmo = _currentAmmo.GetComponent<Rigidbody>();
            Vector3 ammoDirection = _endCanon.position - _baseCanon.position;
            rgbAmmo.AddForce(ammoDirection.normalized * _projectileSpeed);
        }
    }

    // we want to change direction every now and then
    private void ChangeDirection()
    {
        _rotationDirection *= -1;
        Invoke(nameof(ChangeDirection), Random.Range(2, 5));
    }

    private bool CanFire()
    {
        return _currentAmmo == null;
    }
}
