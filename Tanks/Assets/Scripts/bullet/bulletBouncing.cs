using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bulletBouncing : MonoBehaviour
{
    [SerializeField] private int _nbBounce;

    private Rigidbody _rgbBullet;
    private Vector3 _lastVelocity;

    void Start()
    {
        _rgbBullet = GetComponent<Rigidbody>();
    }

    private void LateUpdate()
    {
        _lastVelocity = _rgbBullet.velocity;
    }

    private void OnCollisionEnter(Collision other)
    {
        
        if (other.transform.parent.CompareTag("Walls"))
        {
            if (_nbBounce == 0)
                Destroy(gameObject);
            _nbBounce--;
            Vector3 newDir = Vector3.Reflect(_lastVelocity.normalized, other.contacts[0].normal);

            _rgbBullet.velocity = newDir * _lastVelocity.magnitude;
            transform.rotation = Quaternion.LookRotation(newDir) * Quaternion.Euler(90,0,0);
        }
    }
}
