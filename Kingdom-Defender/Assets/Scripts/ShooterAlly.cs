using UnityEngine;

public class ShooterAlly : Ally
{
    public GameObject projectile;
    public float fireRate;
    public float fireTimer;
    public float raycastDistance;
    public Collider2D safeZoneCollider;
    public LayerMask enemyLayer;

    protected override void Start()
    {
        base.Start();

        GameObject safeZone = GameObject.FindWithTag("SafeZone");
        if (safeZone != null)
        {
            safeZoneCollider = safeZone.GetComponent<Collider2D>();
        }
    }

    protected override void Update()
    {
        if (!isPlaced)
        {
            return;
        }
        fireTimer += Time.deltaTime;

        if (fireTimer >= fireRate && ShouldShoot())
        {
            Shoot();
            fireTimer = 0f;
        }
    }
    bool ShouldShoot()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, raycastDistance, enemyLayer);

        if (hit.collider != null)
        {
            GameObject enemy = hit.collider.gameObject;
            if (!IsInSafeZone(enemy))
            {
                return true;
            }
        }
        return false;
    }

    bool IsInSafeZone(GameObject enemy)
    {
        Collider2D enemyCollider = enemy.GetComponent<Collider2D>();
        if (safeZoneCollider == null && enemyCollider == null)
        {
            return false;
        }

        return safeZoneCollider.bounds.Intersects(enemyCollider.bounds);
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
