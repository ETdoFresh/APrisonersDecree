using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 0.1f;
    public float lifetime = 5;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        transform.position += transform.forward * speed;
    }
}
