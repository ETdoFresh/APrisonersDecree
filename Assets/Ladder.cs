using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Ladder : MonoBehaviour, IPointerClickHandler
{
    public Transform start;
    public Transform destination;

    public void OnPointerClick(PointerEventData eventData)
    {
        MoveClosestPlayerUnit(eventData);
    }

    private void MoveClosestPlayerUnit(PointerEventData eventData)
    {
        var closestPlayer = GetClosestPlayer();
        if (closestPlayer)
            closestPlayer.SetDestination(destination.position);
    }

    private PlayerUnit GetClosestPlayer()
    {
        PlayerUnit closestUnit = null;
        float closestDistance = float.PositiveInfinity;
        foreach (var unit in FindObjectsOfType<PlayerUnit>())
        {
            float distance = Vector3.Distance(unit.transform.position, transform.position);
            if (unit.CanReach(start.position))
                if (distance < closestDistance)
                {
                    closestUnit = unit;
                    closestDistance = distance;
                }
        }
        return closestUnit;
    }
}
