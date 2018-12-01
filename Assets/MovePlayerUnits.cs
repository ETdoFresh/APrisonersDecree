using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MovePlayerUnits : MonoBehaviour
{
    public Transform destination;
    public Text numberOfUnitsText;

    public void MovePlayerUnit()
    {
        List<PlayerUnit> units = new List<PlayerUnit>();

        foreach (var unit in FindObjectsOfType<PlayerUnit>())
            if (!unit.hasMoved)
                units.Add(unit);

        int numberOfUnits = int.Parse(numberOfUnitsText.text);
        numberOfUnits = Math.Min(numberOfUnits, units.Count);

        for (int i = 0; i < numberOfUnits; i++)
        {
            var unit = units[i];
            var navmeshagent = unit.GetComponent<NavMeshAgent>();
            navmeshagent.enabled = false;
            unit.transform.position = destination.position;
            navmeshagent.enabled = true;
            unit.hasMoved = true;
        }
    }
}
