using UnityEngine;
using UnityEngine.AI;

public class SetDestinationClick : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            MoveToMouse();
    }

    private void MoveToMouse()
    {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
            navMeshAgent.SetDestination(hit.point);
    }
}
