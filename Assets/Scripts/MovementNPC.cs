using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementNPC : MonoBehaviour
{
    private NavMeshAgent agent;

    [SerializeField]
    private Transform destination;

    [SerializeField]
    private List<Transform> destinations;

    [SerializeField]
    private float timerStandingStill;

    //+ ajouter liste d'animations
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GameObject[] destGo = GameObject.FindGameObjectsWithTag("Destination");
        for (int i = 0; i < destGo.Length; i++)
        {
            destinations.Add(destGo[i].transform);
        }
        RandomizeDestination();
    }
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(timerStandingStill);
        agent.isStopped = false;
    }
    private void RandomizeDestination()
    {
        Transform tmpTest;
        do
        {
            tmpTest = destinations[Random.Range(0, destinations.Count)];
        } while (tmpTest == destination);
        destination = tmpTest;
        agent.destination = destination.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.position == destination.transform.position)
        {
            agent.isStopped = true;
            RandomizeDestination();
            StartCoroutine(waiter());
        }
    }
}
