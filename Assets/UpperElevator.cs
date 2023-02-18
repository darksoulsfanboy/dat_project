using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperElevator : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform downPos;

    private float speed = 2;
    private bool isStanding;

    private void Update()
    {
        if (isStanding && Input.GetKeyDown(KeyCode.S))
            player.position = downPos.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            transform.Find("Down").gameObject.SetActive(true);
            isStanding = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        transform.Find("Down").gameObject.SetActive(false);
        isStanding = false;
    }
}
