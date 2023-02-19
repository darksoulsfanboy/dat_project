using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private Transform currentCheckpoint;
    private Stats playerHealth;

    private void Start()
    {
        playerHealth = GetComponentInChildren<Stats>();
    }

    public void Respawn()
    {
        transform.position = currentCheckpoint.position;
        RestartLevel.Restart();


    }
}
