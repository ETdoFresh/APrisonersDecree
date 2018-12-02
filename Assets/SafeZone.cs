using UnityEngine;

public class SafeZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var unit = other.GetComponent<PlayerUnit>();
        if (unit) FindObjectOfType<GameManager>().safe.Add(unit);
    }
}
