using System.Collections;
using UnityEngine;

public class ShootAtInterval : MonoBehaviour
{
    public float interval = 1;
    public Transform bulletStartTransform;
    public GameObject bulletPrefab;
    public Coroutine shootAtInterval;

    private void OnEnable()
    {
        shootAtInterval = StartCoroutine(ShootEveryXSeconds());
    }

    private void OnDisable()
    {
        StopCoroutine(shootAtInterval);
        shootAtInterval = null;
    }

    private IEnumerator ShootEveryXSeconds()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            ShootBullet();
        }
    }

    private void ShootBullet()
    {
        Instantiate(bulletPrefab, bulletStartTransform);
    }
}
