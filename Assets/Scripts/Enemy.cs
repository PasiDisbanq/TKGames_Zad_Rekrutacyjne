using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health = 1f;
    
    public event Action OnDeath;

    private float currentHealth;

    private void Start()
    {
        currentHealth = health;
    }

    public void DealDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0f)
        {
            Destroy(this.gameObject);
            OnDeath?.Invoke();
        }
    }
}
