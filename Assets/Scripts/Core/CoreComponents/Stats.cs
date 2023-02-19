using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Stats : CoreComponent
{
    public event Action OnHealthZero;

    [SerializeField] private HealthBar healthBar;
    [SerializeField] private float maxHealth;
    protected float currentHealth { get; private set; }
    public float CurrentHealth => currentHealth;

    protected override void Awake()
    {
        base.Awake();

        currentHealth = maxHealth;
    }

    public void DecreaseHealth(float amount)
    {
        currentHealth -= amount;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            OnHealthZero?.Invoke();
            Debug.Log("dead");
        }
    }

    public void IncreaseHealth(float amount)
    {
        currentHealth += Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        healthBar.SetHealth(currentHealth);
    }

    public void Respawn()
    {
        IncreaseHealth(maxHealth);
        core.transform.parent.gameObject.SetActive(true);
    }
}
