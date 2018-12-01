using System.Collections.Generic;
using UnityEngine;

public class ActivateOnTriggerEnter : MonoBehaviour
{
    public List<GameObject> objectsToActivate = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        foreach (var gameObject in objectsToActivate)
            gameObject.SetActive(true);
    }
}
