using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class turretMovement : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private Plane _plane;

    private void Start()
    {
        _plane = new Plane(Vector3.up, -transform.position.y);
    }

    void FixedUpdate()
    {
        rotateTurret();
    }

    private void rotateTurret()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        float enter;

        if (_plane.Raycast(ray, out enter))
        {
            Vector3 hit = ray.GetPoint(enter);
            transform.LookAt(new Vector3(hit.x, transform.position.y, hit.z));
        }
    }
}
