using UnityEngine;

public class Ally : MonoBehaviour
{
    public Detector currentDetector;
    public GameObject projectile;
    public float fireRate;
    public float fireCooldown;
    public bool isPlaced = false;

    void Update()
    {
        if (fireCooldown > 0f) fireCooldown -= Time.deltaTime;
    }

    public void Shoot()
    {
        if (fireCooldown > 0f || !isPlaced) return;
        fireCooldown = 1f / fireRate;
        Instantiate(projectile, transform.position, Quaternion.identity);
    }
}
