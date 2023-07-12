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
            BounceBall(other);

        if (other.transform.CompareTag("Player"))
            ApplyDamage(other);
    }

    private void BounceBall(Collision other)
    {
        // if already bounced, play audio/vfx and destroy
        if (_nbBounce == 0)
        {
            DestroyBullet();
            return;
        }
            
        // play the bouncing sounds, bounce the bullet and rotate to follow the movement
        _nbBounce--;

        _audioSource.PlayOneShot(_bouncingSound);
            
        Vector3 newDir = Vector3.Reflect(_lastVelocity.normalized, other.contacts[0].normal);

        _rgbBullet.velocity = newDir * _lastVelocity.magnitude;
        transform.rotation = Quaternion.LookRotation(newDir) * Quaternion.Euler(90,0,0);
    }

    // pretty self explanatory
    private void ApplyDamage(Collision other)
    {
        HealthSystem healthSystem = other.transform.GetComponent<HealthSystem>();
        healthSystem.TakeDamage();
        DestroyBullet();
    }

    // Could use OnDestroy but the audio would cut.
    private void DestroyBullet()
    {
        Instantiate(_explosionVfx, transform);
        _audioSource.PlayOneShot(_explosionSound);
                
        // delayed for the audio/vfx to play (ps: you could instantiate with a vector instead of a transform
        //                                      to solve this but the problem remains the same for the audio so
        //                                      I left it like that)
        GetComponent<TrailRenderer>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        Destroy(gameObject, 1f);
    }
}
