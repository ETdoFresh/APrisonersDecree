using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Interactable : MonoBehaviour//, IPointerClickHandler
{
    public UnityEventGameObject onPlayerUnitTriggerEnter;
    public UnityEventGameObject onAllPlayerUnitsTriggerExit;
    public List<Collider> triggerers = new List<Collider>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerUnit>())
        {
            onPlayerUnitTriggerEnter.Invoke(other.gameObject);
            triggerers.Add(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        triggerers.Remove(other);
        if (triggerers.Count == 0)
            onAllPlayerUnitsTriggerExit.Invoke(other.gameObject);
    }

    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    MoveClosestPlayerUnit(eventData);
    //}

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
