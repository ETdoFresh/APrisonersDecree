using System.Collections.Generic;
using UnityEngine;

public class LerpObjectOnTriggerEnter : MonoBehaviour
{
    public Transform objectToSlide;
    public Vector3 closedPosition;
    public Vector3 openedPosition;
    public Vector3 targetPosition;
    public List<Transform> contains = new List<Transform>();

    private void Awake()
    {
        targetPosition = objectToSlide.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        contains.Add(other.transform);
        if (contains.Count >= 0)
            targetPosition = openedPosition;
    }
    private void OnTriggerExit(Collider other)
    {
        contains.Remove(other.transform);
        if (contains.Count == 0)
            targetPosition = closedPosition;
    }

    private void Update()
    {
        objectToSlide.position = Vector3.MoveTowards(objectToSlide.transform.position, targetPosition, 0.1f);
    }
}
