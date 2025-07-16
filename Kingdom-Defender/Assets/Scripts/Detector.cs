using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public List<Ally> allies = new List<Ally>();
    public List<Enemy> enemies = new List<Enemy>();

    void Start()
    {
        InvokeRepeating(nameof(Trigger), 0f, 0.2f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null && !enemies.Contains(enemy))
            {
                enemies.Add(enemy);
                Trigger();
            }
        }

        if (other.CompareTag("Ally"))
        {
            Ally ally = other.GetComponent<Ally>();
            if (ally != null && !allies.Contains(ally))
            {
                allies.Add(ally);
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null && enemies.Contains(enemy))
            {
                enemies.Remove(enemy);
            }
        }

        if (other.CompareTag("Ally"))
        {
            Ally ally = other.GetComponent<Ally>();
            if (ally != null && allies.Contains(ally))
            {
                allies.Remove(ally);
            }
        }
    }
    public void Trigger()
    {
        allies.RemoveAll(a => a == null);
        enemies.RemoveAll(e => e == null);
        if (enemies.Count == 0) return;

        foreach (Ally ally in allies)
        {
            ally.Shoot();
        }
    }
}
