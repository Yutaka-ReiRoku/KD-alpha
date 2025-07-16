using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;
    private float currentHealth;

    public bool isAttacking = false;

    void Start()
    {
        currentHealth = health;
    }

    void Update()
    {
        if (!isAttacking)
        {
            Move();
        }
    }

    void Move()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ally"))
        {
            isAttacking = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ally"))
        {
            isAttacking = false;
        }
    }
}
