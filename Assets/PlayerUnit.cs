using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerUnit : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public NavMeshAgent navMeshAgent;
    public Animator animator;
    public bool isBusy = false;
    public bool hasMoved = false;
    public PlayerUnit dragged;

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
        UnitTracker.Remove(1);
        FindObjectOfType<GameManager>().Remove(this);
        animator.SetTrigger("Die");
        animator.SetBool("IsDead", true);
        Destroy(this);
        Destroy(navMeshAgent);
        Destroy(GetComponent<Collider>());
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!dragged) return;
        dragged = null;

        var destination = eventData.pointerCurrentRaycast.worldPosition;
        if (CanReach(destination))
            SetDestination(destination);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        dragged = this;
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }
}
