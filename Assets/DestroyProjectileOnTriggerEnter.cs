using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectileOnTriggerEnter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var projectile = other.GetComponent<Projectile>();
        if (projectile) Destroy(projectile.gameObject);
    }
}
