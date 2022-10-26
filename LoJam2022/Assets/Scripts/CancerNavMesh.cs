using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CancerNavMesh : MonoBehaviour
{
    [SerializeField] private float wanderRadius;
    [SerializeField] private float radiusMin;
    [SerializeField] private float wanderTimer;

    private NavMeshAgent agent;
    private float timer;
    private bool destroying = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer && !destroying)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius + radiusMin, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Blood Cell") && !destroying && enabled)
        {
            destroying = true;
            collision.gameObject.GetComponent<CellTypeManager>().BloodToCancer();
            StartCoroutine(DestroyBloodCell(collision));
        }
    }

    IEnumerator DestroyBloodCell(Collision collision)
    {
        agent.SetDestination(collision.transform.position);
        yield return new WaitForSeconds(3);
        destroying = false;
    }
}
