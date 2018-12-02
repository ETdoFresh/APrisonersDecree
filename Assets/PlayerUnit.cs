using UnityEngine;
using UnityEngine.AI;

public class PlayerUnit : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Animator animator;
    public bool isBusy = false;
    public bool hasMoved = false;

    private void Awake()
    {
        FindObjectOfType<GameManager>().Add(this);
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        animator.SetFloat("Velocity", navMeshAgent.velocity.magnitude);
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
        animator.SetTrigger("Die");
        animator.SetBool("IsDead", true);
        Destroy(this);
        Destroy(navMeshAgent);
    }
}
