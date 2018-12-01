using UnityEngine;

public class DestroyOnCollide : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var playerUnit = other.GetComponent<PlayerUnit>();
        if (playerUnit)
        {
            playerUnit.Die();
            Destroy(gameObject);
        }
    }
}
