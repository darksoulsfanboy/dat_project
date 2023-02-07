using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackState : AttackState
{
    private Movement Movement { get => movement ??= core.GetCoreComponent<Movement>(); }
    private CollisionSenses CollisionSenses { get => collisionSenses ??= core.GetCoreComponent<CollisionSenses>(); }

    protected Movement movement;
    private CollisionSenses collisionSenses;

    protected D_MeleeAttack meleeAttack;

    public MeleeAttackState(Entity entity, EnemyFiniteStateMachine stateMachine, string animBoolName, Transform attackPos, D_MeleeAttack meleeAttack) : base(entity, stateMachine, animBoolName, attackPos)
    {
        this.meleeAttack = meleeAttack;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();

        Collider2D[] detectedObjs = Physics2D.OverlapCircleAll(attackPos.position, meleeAttack.AttackRadius, meleeAttack.whatIsPlayer);

        foreach (Collider2D collider in detectedObjs)
        {
            IDamageable damageable = collider.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.Damage(meleeAttack.AttackDamage);
            }

            IKnockbackable knockbackable = collider.GetComponent<IKnockbackable>();

            if (knockbackable != null)
            {
                knockbackable.Knockback(meleeAttack.knockbackAngle, meleeAttack.knockbackStrength, Movement.FacingDirection);
            }
        }
    }
}
