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
    //+ ajouter liste d'animations
    private bool isStandingStill = true;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GameObject[] destGo = GameObject.FindGameObjectsWithTag("Destination");
        for (int i = 0; i < destGo.Length; i++)
        {
            destinations.Add(destGo[i].transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStandingStill) { 
            agent.destination = destination.position;
        }
        if (isStandingStill)
        {
            randomizeDestination();
        }
    }

    private void randomizeDestination()
    {
        Transform tmpTest;
        do
        {
            tmpTest = destinations[Random.Range(0, destinations.Count)];
        } while (tmpTest == destination);
        destination = tmpTest;
        isStandingStill = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.position == destination.transform.position)
        {
            isStandingStill = true;
        }
    }
}
