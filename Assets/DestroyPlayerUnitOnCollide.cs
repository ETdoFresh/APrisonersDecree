using UnityEngine;

public class DestroyPlayerUnitOnCollide : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var unit = other.GetComponent<PlayerUnit>();
        if (unit)
            unit.Die();
    }
}
