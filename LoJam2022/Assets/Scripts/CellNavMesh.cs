using UnityEngine;
using UnityEngine.AI;

public class CellNavMesh : MonoBehaviour
{
    [SerializeField] private GameObject[] endPoints;
    [SerializeField] private GameObject[] spawnPoints;

    public bool targetAquired = false;
    private NavMeshAgent agent;
    private NavMeshPath path;
    private bool converting = false;
    private Rigidbody rb;

    void Start()
    {
        path = new NavMeshPath();
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
            agent.CalculatePath(target, path);
            agent.SetPath(path);
            //agent.SetDestination(target);
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
        if (enabled && !converting && other.tag == "Destination")
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


