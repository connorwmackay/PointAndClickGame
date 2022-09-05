using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private Transform playerTransform;
    private NavMeshAgent navMeshAgent;

    void Awake()
    {
        playerTransform = GetComponent<Transform>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void MoveToPoint(Vector3 point)
    {
        navMeshAgent.destination = point;
    }
}
