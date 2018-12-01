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
        {
            var path = new NavMeshPath();
            navMeshAgent.CalculatePath(hit.point, path);
            if (path.status != NavMeshPathStatus.PathPartial)
                navMeshAgent.SetDestination(hit.point);
        }
    }
}
