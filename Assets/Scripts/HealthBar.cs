using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public GameObject health;
    public float hpPerSecond = 2;

    private Quaternion origRotation;

    public void SetHealth(float health)
    {
        healthBar.value = health;
    }

    private void Start()
    {
        origRotation = health.transform.rotation;
    }

    private void Update()
    {
        health.transform.position = transform.position;
        health.transform.rotation = origRotation;

        if (transform.CompareTag("Player"))
        {
            healthBar.value -= Time.deltaTime * hpPerSecond;
        }
    }

}
