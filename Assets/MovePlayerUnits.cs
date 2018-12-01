using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MovePlayerUnits : MonoBehaviour
{
    public Transform destination;
    public Text numberOfUnitsText;

    public void MovePlayerUnit()
    {
        var units = FindObjectsOfType<PlayerUnit>();
        int numberOfUnits = int.Parse(numberOfUnitsText.text);
        numberOfUnits = Math.Min(numberOfUnits, units.Length);

        for (int i = 0; i < numberOfUnits; i++)
        {
            var navmeshagent = units[i].GetComponent<NavMeshAgent>();
            navmeshagent.enabled = false;
            units[i].transform.position = destination.position;
            navmeshagent.enabled = true;
        }
    }
}
