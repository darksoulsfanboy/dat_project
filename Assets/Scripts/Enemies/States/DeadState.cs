using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : EnemyState
{
    protected D_DeadState deadState;
    public DeadState(Entity entity, EnemyFiniteStateMachine stateMachine, string animBoolName, D_DeadState deadState) : base(entity, stateMachine, animBoolName)
    {
        this.deadState = deadState;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        GameObject.Instantiate(deadState.deathBloodParticle, entity.transform.position, deadState.deathBloodParticle.transform.rotation);
        GameObject.Instantiate(deadState.deathChunkParticle, entity.transform.position, deadState.deathChunkParticle.transform.rotation);

        entity.gameObject.SetActive(false);

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
