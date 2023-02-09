using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : CoreComponent
{
    [SerializeField] private GameObject[] deathParticles;
    [SerializeField] private Stats playerStats;
    [SerializeField] private float hpToIncrease = 5;

    private ParticleManager ParticleManager =>
        particleManager ? particleManager : core.GetCoreComponent<ParticleManager>();

    private ParticleManager particleManager;

    private Stats Stats => stats ? stats : core.GetCoreComponent<Stats>();
    private Stats stats;

    public void Die()
    {
        foreach (var particle in deathParticles)
        {
            ParticleManager.StartParticles(particle);
        }

        core.transform.parent.gameObject.SetActive(false);
        playerStats.IncreaseHealth(hpToIncrease);

    }

    private void OnEnable()
    {
        Stats.OnHealthZero += Die;
    }

    private void OnDisable()
    {
        Stats.OnHealthZero -= Die;
    }
}
