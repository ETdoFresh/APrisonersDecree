using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    public bool isBusy = false;
    public bool hasMoved = false;

    public void Die()
    {
        Destroy(gameObject);
    }
}
