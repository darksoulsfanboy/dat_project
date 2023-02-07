using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newMeleeAttackStateData", menuName = "Data/State Data/Melee Attack State")]
public class D_MeleeAttack : ScriptableObject
{
    public float AttackRadius = 0.5f;
    public float AttackDamage = 10f;

    public Vector2 knockbackAngle = Vector2.one;
    public float knockbackStrength = 10f;

    public LayerMask whatIsPlayer;
}
