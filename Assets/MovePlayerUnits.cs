using System;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MovePlayerUnits : MonoBehaviour
{
    public Transform destination;
    public Text numberOfUnitsText;

    public void MovePlayerUnit()
    {
        var spawnArea = FindObjectOfType<SpawnArea>().GetComponent<Collider>();
        var units = FindObjectsOfType<PlayerUnit>().AsEnumerable();
        units = units.Where(unit => spawnArea.bounds.Intersects(unit.GetComponent<Collider>().bounds));
        int numberOfUnits = int.Parse(numberOfUnitsText.text);
        numberOfUnits = Math.Min(numberOfUnits, units.Count());

        for (int i = 0; i < numberOfUnits; i++)
        {
            var unit = units.ElementAt(i);
            var navmeshagent = unit.GetComponent<NavMeshAgent>();
            navmeshagent.enabled = false;
            unit.transform.position = destination.position;
            navmeshagent.enabled = true;
        }
    }
}
