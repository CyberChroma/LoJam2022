using UnityEngine;
using UnityEngine.AI;

public class CellNavMesh : MonoBehaviour
{
    [SerializeField] private GameObject[] endPoints;
    [SerializeField] private GameObject[] spawnPoints;

    private bool targetAquired = false;
    private NavMeshAgent agent;
    private bool converting = false;
    private Rigidbody rb;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        converting = false;
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
        if (enabled && !converting)
        {
            Vector3 target = ChooseDestination(spawnPoints);
            transform.position = target;
            targetAquired = false;
            rb.velocity = Vector3.zero;    
            
        }
    }

    public void StopMoving()
    {
        converting = true;
        agent.SetDestination(transform.position);
    }

}


