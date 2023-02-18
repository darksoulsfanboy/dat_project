using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform downPos;
    [SerializeField] private Transform upperPos;

    private float speed = 2;
    private bool isStanding;

    private void Update()
    {
        if (isStanding && Input.GetKeyDown(KeyCode.W))
            player.position = upperPos.position;

        else if (isStanding && Input.GetKeyDown(KeyCode.S))
            player.position = downPos.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            try
            {
                transform.Find("Up").gameObject.SetActive(true);
                transform.Find("Down").gameObject.SetActive(true);
            }

            catch
            {
                Debug.Log("Opa");
            }
            isStanding = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            try
            {
                transform.Find("Up").gameObject.SetActive(false);
                transform.Find("Down").gameObject.SetActive(false);
            }

            catch
            {
                Debug.Log("Opa");
            }
            isStanding = false;
        }
    }
}
