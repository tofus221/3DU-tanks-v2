using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lessDumbTurretAI : MonoBehaviour
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
        RaycastHit hit;
        // fires bullet when it sees the player
        if (Physics.Raycast(_tower.position, _endCanon.position - _baseCanon.position, out hit, 100, LayerMask.GetMask("Player", "Walls"))
            && CanFire())
        {
            Debug.Log(hit.transform.name);
            if (hit.transform.CompareTag("Walls"))
                return;
            _currentAmmo = Instantiate(_bullet, _endCanon.position, _tower.rotation * Quaternion.Euler(90, 0, 0));
            Rigidbody rgbAmmo = _currentAmmo.GetComponent<Rigidbody>();
            Vector3 ammoDirection = _endCanon.position - _baseCanon.position;
            rgbAmmo.AddForce(ammoDirection.normalized * _projectileSpeed);
        }
    }

    // we want to change direction every now and then
    private void ChangeDirection()
    {
        // the goal here is to make the rotation fo towards the player, so if the rotation is already heading towards the player it should do nothing.
        Plane plane = new Plane(_baseCanon.position, _baseCanon.position + Vector3.up, _endCanon.position);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _rotationDirection = plane.GetSide(player.transform.position) ? 1 : -1;
        
        Invoke(nameof(ChangeDirection), Random.Range(2, 5));
    }

    private bool CanFire()
    {
        return _currentAmmo == null;
    }
}
