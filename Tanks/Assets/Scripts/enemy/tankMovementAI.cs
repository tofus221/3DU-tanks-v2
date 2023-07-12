using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class tankMovementAI : MonoBehaviour
{
    private NavMeshAgent _navMesh;

    [SerializeField] private float _changeDirectionRadius;
    

    private void Start()
    {
        _navMesh = GetComponent<NavMeshAgent>();
        ChangeDirection();
    }

    private void Update()
    {
        // when destination is reached change direction
        if (_navMesh.remainingDistance <= 1)
            ChangeDirection();
    }

    // pick a point at random in a circle around the game object then take the closest point in the navmesh and set destination if hit
    private void ChangeDirection()
    {
        Vector3 randomDir = transform.position + Random.insideUnitSphere * _changeDirectionRadius;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDir, out hit, _changeDirectionRadius, 1))
        {
            // Debug.Log("change direction:" + new Vector3(hit.position.x, 1, hit.position.z));
            _navMesh.SetDestination(new Vector3(hit.position.x, 1, hit.position.z));
        }
        else
            ChangeDirection();
    }
}
