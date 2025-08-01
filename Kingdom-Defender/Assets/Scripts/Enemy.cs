using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;
    public float currentHealth;
    public float damage;
    public float attackRate;
    public float attackTimer;

    public bool isAttacking = false;
    public Ally ally;

    public Collider2D safeZoneCollider;

    void Start()
    {
        currentHealth = health;

        GameObject safeZone = GameObject.FindWithTag("SafeZone");
        if (safeZone != null)
        {
            safeZoneCollider = safeZone.GetComponent<Collider2D>();
        }
    }

    void Update()
    {
        if (!isAttacking)
        {
            Move();
        }
        else if(ally != null)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackRate)
            {
                ally.TakeDamage(damage);
                attackTimer = 0;
            }
        }
    }

    void Move()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void TakeDamage(float damage)
    {
        if (IsInSafeZone())
        {
            return;
        }
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

    bool IsInSafeZone()
    {
        Collider2D enemyCollider = GetComponent<Collider2D>();
        if (safeZoneCollider == null && enemyCollider == null)
        {
            return false;
        }

        return safeZoneCollider.bounds.Intersects(enemyCollider.bounds);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Ally"))
        {
            ally = collider.GetComponent<Ally>();
            if (ally != null)
            {
                isAttacking = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Ally"))
        {
            isAttacking = false;
        }
    }
}
