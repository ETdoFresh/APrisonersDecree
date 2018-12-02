using UnityEngine;
using UnityEngine.AI;

public class PlayerUnit : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public bool isBusy = false;
    public bool hasMoved = false;

    private void Awake()
    {
        FindObjectOfType<GameManager>().Add(this);
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void SetDestination(Vector3 target)
    {
        navMeshAgent.SetDestination(target);
    }

    public bool CanReach(Vector3 targetPosition)
    {
        var path = new NavMeshPath();
        navMeshAgent.CalculatePath(targetPosition, path);
        return path.status == NavMeshPathStatus.PathComplete;
    }

    public void Die()
    {
        FindObjectOfType<GameManager>().Remove(this);
        Destroy(gameObject);
    }
}
