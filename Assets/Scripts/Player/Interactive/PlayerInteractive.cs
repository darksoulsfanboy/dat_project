using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractive : MonoBehaviour
{
    private float rayDistance = 3f;

    [SerializeField] private LayerMask layerMask;

    private PlayerInputHandler inputManager;

    private void Start()
    {
        inputManager = GetComponent<PlayerInputHandler>();
    }

    private void Update()
    {
        Ray2D ray = new Ray2D(transform.position, Vector2.right * Mathf.Cos(transform.rotation.z));

        RaycastHit2D hitInfo = Physics2D.Raycast(ray.origin, ray.direction, rayDistance, layerMask);

        if (hitInfo)
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hitInfo.collider.GetComponent<Interactable>().BaseInteract();
                }
            }
        }
    }
}
