using UnityEditor.PackageManager;
using UnityEngine;

public class Ally : MonoBehaviour
{
    public float health;
    public float currentHealth;
    public bool isPlaced = false;

    public int cost;

    protected virtual void Start()
    {
        currentHealth = health;
    }

    protected virtual void Update()
    {

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
