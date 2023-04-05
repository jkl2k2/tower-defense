using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed = 10f;
    
    public float startHealth = 100;
    private float health;
    
    [FormerlySerializedAs("value")] public int worth = 50;

    public GameObject deathEffect;

    [Header("Unity Stuff")] public Image healthBar;

    private void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }

    void Die()
    {
        PlayerStats.Money += worth;
        
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 3f);

        WaveSpawner.EnemiesAlive--;
        
        Destroy(gameObject);
    }
}
