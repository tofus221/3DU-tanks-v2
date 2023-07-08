using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class tankMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float speed;
    [SerializeField] private float angularSpeed;

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float playerVerticalInput = Input.GetAxis("Vertical");
        float playerHorizontalInput = Input.GetAxis("Horizontal");

        _rigidbody.AddRelativeForce(Vector3.forward * (playerVerticalInput * speed));
        _rigidbody.AddRelativeTorque(new Vector3(0,1,0) * (playerHorizontalInput * angularSpeed));
        // transform.Translate(Vector3.forward * (playerVerticalInput * speed * Time.fixedDeltaTime));
        // transform.Rotate(new Vector3(0,1,0) * (playerHorizontalInput * angularSpeed * Time.fixedDeltaTime));
    }
}
