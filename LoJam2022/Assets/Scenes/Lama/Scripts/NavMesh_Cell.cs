using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh_Cell : MonoBehaviour
{
    [SerializeField] private GameObject[] endPoints;
    [SerializeField] private GameObject[] gameObjects;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        agent.SetDestination(endPoints[0].transform.position);
    }
}
