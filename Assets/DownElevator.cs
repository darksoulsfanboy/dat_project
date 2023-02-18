using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownElevator : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform upperPos;

    private float speed = 2;
    private bool isStanding;

    private void Update()
    {

        if (isStanding && Input.GetKeyDown(KeyCode.W))
            player.position = upperPos.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            transform.Find("Up").gameObject.SetActive(true);
            isStanding = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        transform.Find("Up").gameObject.SetActive(false);
        isStanding = false;
    }
}
