using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CellNavMesh : MonoBehaviour
{
    [SerializeField] private GameObject[] endPoints;
    [SerializeField] private GameObject[] spawnPoints;

    private bool targetAquired = false;
    private NavMeshAgent agent;
    CellTypeManager blood;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        blood = GetComponent<CellTypeManager>();
    }

    private void Update()
    {
        if (!targetAquired)
        {
            Vector3 target = ChooseDestination(endPoints);
            agent.SetDestination(target);
            targetAquired = true;
        }
    }

    private Vector3 ChooseDestination(GameObject[] array)
    {
        int index = Random.Range(0, array.Length);
        return array[index].transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (enabled)
        {
            Vector3 target = ChooseDestination(spawnPoints);
            transform.position = target;
            targetAquired = false;
        }
        
    }


}


