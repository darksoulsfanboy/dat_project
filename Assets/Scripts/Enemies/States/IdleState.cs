using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : EnemyState
{
    private Movement Movement { get => movement ??= core.GetCoreComponent<Movement>(); }
    private CollisionSenses CollisionSenses { get => collisionSenses ??= core.GetCoreComponent<CollisionSenses>(); }

    protected Movement movement;
    private CollisionSenses collisionSenses;

    protected D_IdleState idleData;

    protected bool flipAfterIdle;
    protected bool isIdleTimeOver;
    protected bool isPlayerInMinAgroRange;
    protected float idleTime;

    public IdleState(Entity entity, EnemyFiniteStateMachine stateMachine, string animBoolName, D_IdleState idleData) : base(entity, stateMachine, animBoolName)
    {
        this.idleData = idleData;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
    }

    public override void Enter()
    {
        base.Enter();

        Movement?.SetVelocityX(0f);
        isIdleTimeOver = false;
        SetRandomIdleTime();

    }

    public override void Exit()
    {
        base.Exit();

        if (flipAfterIdle)
        {
            Movement?.Flip();
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        Movement?.SetVelocityX(0f);

        if (Time.time >= startTime + idleTime)
        {
            isIdleTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public void SetFlipAfterIdle(bool flip)
    {
        flipAfterIdle = flip;
    }

    private void SetRandomIdleTime()
    {
        idleTime = Random.Range(idleData.minIdleTime, idleData.maxIdleTime);
    }
}