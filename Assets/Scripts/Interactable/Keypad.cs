using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Interactable
{
    [SerializeField] private Animator door;

    protected override void Interact()
    {
        base.Interact();

        door.SetBool("isOpen", true);
    }
}
