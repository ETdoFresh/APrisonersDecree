using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    public bool hasMoved = false;

    public void Die()
    {
        Destroy(gameObject);
    }
}
