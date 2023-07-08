using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankFiringSystem : MonoBehaviour
{
    [SerializeField] private Transform _baseCanon; // used to calculate bullet trajectory to match canon orientation
    [SerializeField] private Transform _spawner;
    [SerializeField] private GameObject _projectile;

    [SerializeField] private float _projectileSpeed;
    [SerializeField] private float _reloadTime;
    [SerializeField] private float _firingRate;
    private float _lastTimeFire;
    
    [SerializeField] private int _ammunition;
    private int _currAmmunition;
    

    [SerializeField] private Transform turretTransform; // useful to get the rotation of the turret


    void Start()
    {
        _lastTimeFire = 0f;
        _currAmmunition = _ammunition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canFire())
        {
            Debug.Log("ammo: " + _currAmmunition);
            _lastTimeFire = Time.time;
            _currAmmunition--;
            GameObject Bullet = Instantiate(_projectile, _spawner.position, Quaternion.identity);
            Bullet.transform.rotation = turretTransform.rotation * Quaternion.Euler(90, 0, 0);
            Rigidbody BulletRigiBody = Bullet.GetComponent<Rigidbody>();
            Vector3 bulletDirection = _spawner.position - _baseCanon.position;
            BulletRigiBody.AddForce(bulletDirection.normalized * _projectileSpeed);
            if (_currAmmunition == 0)
                Invoke(nameof(reload), _reloadTime);
        }
    }

    private bool canFire()
    {
        return _currAmmunition > 0 && Time.time >= _lastTimeFire + (1 / _firingRate);
    }

    private void reload()
    {
        _currAmmunition = _ammunition;
    }
}
