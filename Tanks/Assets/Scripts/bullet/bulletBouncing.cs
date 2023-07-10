using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bulletBouncing : MonoBehaviour
{
    [SerializeField] private int _nbBounce;

    private AudioSource _audioSource;
    [Space] [SerializeField] private AudioClip _bouncingSound;
    [SerializeField] private AudioClip _explosionSound;
    
    [Space] [SerializeField] private GameObject _explosionVfx;

    private Rigidbody _rgbBullet;
    private Vector3 _lastVelocity;

    void Start()
    {
        _rgbBullet = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void LateUpdate()
    {
        _lastVelocity = _rgbBullet.velocity;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Walls"))
        {
            // if already bounced, play audio/vfx and destroy
            if (_nbBounce == 0)
            {
                Instantiate(_explosionVfx, transform);
                _audioSource.PlayOneShot(_explosionSound);
                
                // delayed for the audio/vfx to play
                GetComponent<TrailRenderer>().enabled = false;
                GetComponent<MeshRenderer>().enabled = false;
                Destroy(gameObject, 1f);
                return;
            }
            
            // play the bouncing sounds, bounce the bullet and rotate to follow the movement
            _nbBounce--;

            _audioSource.PlayOneShot(_bouncingSound);
            
            Vector3 newDir = Vector3.Reflect(_lastVelocity.normalized, other.contacts[0].normal);

            _rgbBullet.velocity = newDir * _lastVelocity.magnitude;
            transform.rotation = Quaternion.LookRotation(newDir) * Quaternion.Euler(90,0,0);
        }
    }
}
