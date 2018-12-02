using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class SetDestinationClick : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        foreach (var unit in FindObjectsOfType<PlayerUnit>())
            MoveToMouse(unit, eventData);
    }

    private void MoveToMouse(PlayerUnit unit, PointerEventData eventData)
    {
        if (unit.isBusy) return;

        var navMeshAgent = unit.GetComponent<NavMeshAgent>();
        if (!navMeshAgent) return;

        var worldPosition = eventData.pointerCurrentRaycast.worldPosition;
        var path = new NavMeshPath();
        navMeshAgent.CalculatePath(worldPosition, path);
        if (path.status == NavMeshPathStatus.PathComplete)
            navMeshAgent.SetDestination(worldPosition);
    }
}
