using UnityEditor.PackageManager;
using UnityEngine;

public class Ally : MonoBehaviour
{
    public GameObject projectile;
    public float fireRate;
    public float fireTimer;
    public float raycastDistance;
    public Collider2D safeZoneCollider;
    public LayerMask enemyLayer;

    public float health;
    public float currentHealth;
    public bool isPlaced = false;

    void Start()
    {
        currentHealth = health;

        GameObject safeZone = GameObject.FindWithTag("SafeZone");
        if (safeZone!= null)
        {
            safeZoneCollider = safeZone.GetComponent<Collider2D>();
        }
    }

    void Update()
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

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * raycastDistance);
    }
}
