using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Death : CoreComponent
{
    [SerializeField] private GameObject[] deathParticles;
    [SerializeField] private Stats playerStats;
    [SerializeField] private float hpToIncrease = 5;
    [SerializeField] private Button restart;
    [SerializeField] private BlackScreenFade fade;

    private Animator anim;
    private PlayerRespawn playerRespawn;

    private ParticleManager ParticleManager =>
        particleManager ? particleManager : core.GetCoreComponent<ParticleManager>();

    private ParticleManager particleManager;

    private Stats Stats => stats ? stats : core.GetCoreComponent<Stats>();
    private Stats stats;


    private void Start()
    {
        playerRespawn = GetComponentInParent<PlayerRespawn>();
        anim = GetComponentInParent<Animator>();
    }

    public void Die()
    {
        foreach (var particle in deathParticles)
        {
            ParticleManager.StartParticles(particle);
        }


        if (core.transform.parent.tag == "Player" || core.transform.parent.tag == "Invincible")
        {
            anim.SetTrigger("isDead");
            fade.isDead = true;
            restart.gameObject.SetActive(true);


            GameObject player = core.transform.parent.gameObject;

            player.layer = 0;
            player.tag = "Invincible";
            player.GetComponent<PlayerInput>().enabled = false;
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            core.transform.gameObject.SetActive(false);
        }

        else
        {
            core.transform.parent.gameObject.SetActive(false);
        }


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
