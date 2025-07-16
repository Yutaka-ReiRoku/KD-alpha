using UnityEngine;

public class Ally : MonoBehaviour
{
    public GameObject projectile;
    public float fireRate;
    public float fireTimer;
    public float raycastDistance;
    public bool isPlaced = false;

    public Collider2D safeZoneCollider;
    public LayerMask zombieLayer;

    void Start()
    {
        GameObject safeZone = GameObject.FindWithTag("SafeZone");
        if (safeZone!= null)
        {
            safeZoneCollider = safeZone.GetComponent<Collider2D>();
        }
    }

    void Update()
    {
        fireTimer += Time.deltaTime;

        if (fireTimer >= fireRate && ShouldShoot())
        {
            Shoot();
            fireTimer = 0f;
        }
    }

    bool ShouldShoot()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, raycastDistance, zombieLayer);

        if (hit.collider != null)
        {
            GameObject zombie = hit.collider.gameObject;
            if (!IsInSafeZone(zombie))
            {
                return true;
            }
        }
        return false;
    }

    bool IsInSafeZone(GameObject zombie)
    {
        if (safeZoneCollider == null)
        {
            return false;
        }

        Collider2D zombieCollider = zombie.GetComponent<Collider2D>();
        if (zombieCollider == null)
        {
            return false;
        }

        return safeZoneCollider.bounds.Intersects(zombieCollider.bounds);
    }

    void Shoot()
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * raycastDistance);
    }
}
