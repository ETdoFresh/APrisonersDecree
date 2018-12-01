using UnityEngine;

public class LerpObjectOnTriggerEnter : MonoBehaviour
{
    public Transform objectToSlide;
    public Vector3 closedPosition;
    public Vector3 openedPosition;
    public Vector3 targetPosition;

    private void Awake()
    {
        targetPosition = objectToSlide.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        targetPosition = openedPosition;
    }
    private void OnTriggerExit(Collider other)
    {
        targetPosition = closedPosition;
    }

    private void Update()
    {
        objectToSlide.position = Vector3.MoveTowards(objectToSlide.transform.position, targetPosition, 0.1f);
    }
}
