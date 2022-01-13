using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class NavMeshTest : MonoBehaviour
{
    [SerializeField]
    private List<Transform> waypoints;

    private NavMeshAgent agent;
    private int nextPosition;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (agent == null)
        {
            Debug.LogError("no agent found");
        }

        if (!waypoints.Any() || waypoints[nextPosition] == null)
        {
            
            Debug.LogError("no waypoints to go");
        }
        else
        {
            Debug.Log("we have " + waypoints.Count + " waypoints");
        }
    }


    void Update()
    {
        agent.destination = waypoints[nextPosition].position;

        if (transform.position != waypoints[nextPosition].position) return;

        nextPosition++;


        if (nextPosition != waypoints.Count) return;

        nextPosition = 0;
    }
}
