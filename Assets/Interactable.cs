using UnityEngine;
using UnityEngine.EventSystems;

public class Interactable : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        MoveClosestPlayerUnit(eventData);
    }

    private void MoveClosestPlayerUnit(PointerEventData eventData)
    {
        var worldPosition = eventData.pointerCurrentRaycast.worldPosition;
        var closestPlayer = GetClosestPlayer(worldPosition);
        if (closestPlayer)
            closestPlayer.SetDestination(transform.position);
    }

    private PlayerUnit GetClosestPlayer(Vector3 position)
    {
        PlayerUnit closestUnit = null;
        float closestDistance = float.PositiveInfinity;
        foreach (var unit in FindObjectsOfType<PlayerUnit>())
        {
            float distance = Vector3.Distance(unit.transform.position, transform.position);
            if (unit.CanReach(position))
                if (distance < closestDistance)
                {
                    closestUnit = unit;
                    closestDistance = distance;
                }
        }
        return closestUnit;
    }
}
