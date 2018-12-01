using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class WaypointFollow : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public List<Transform> waypoints;
    public int currentWaypointIndex;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (!navMeshAgent.pathPending)
        {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f)
                {
                    currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
                    navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
                }
            }
        }
    }
}
