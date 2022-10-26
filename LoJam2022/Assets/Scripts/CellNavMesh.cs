using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CellNavMesh : MonoBehaviour
{
    [SerializeField] private GameObject[] endPoints;
    [SerializeField] private GameObject[] spawnPoints;

    [SerializeField] private float lerpDuration = 3;
    [SerializeField] private float startValue = 0;
    [SerializeField] private float endValue = 10;
    [SerializeField] private float valueToLerp;

    private bool targetAquired = false;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
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
        StartCoroutine(Lerp());
        Vector3 target = ChooseDestination(spawnPoints);
        transform.position = target;
        targetAquired = false;
    }

    IEnumerator Lerp()
    {
        float timeElapsed = 0;
        while (timeElapsed < lerpDuration)
        {
            valueToLerp = Mathf.Lerp(startValue, endValue, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        valueToLerp = endValue;
    }

}


