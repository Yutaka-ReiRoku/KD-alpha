using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;
    public float currentHealth;

    void Start()
    {
        currentHealth = health;
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
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
}
