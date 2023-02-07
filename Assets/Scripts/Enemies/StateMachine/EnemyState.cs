using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    protected Entity entity;
    protected EnemyFiniteStateMachine stateMachine;
    protected Core core;

    protected float startTime;

    private string animBoolName;

    public EnemyState(Entity entity, EnemyFiniteStateMachine stateMachine, string animBoolName)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
        core = entity.Core;
    }

    public virtual void DoChecks()
    {
    }

    public virtual void Enter()
    {
        DoChecks();
        startTime = Time.time;
        entity.Anim.SetBool(animBoolName, true);
    }

    public virtual void Exit()
    {
        entity.Anim.SetBool(animBoolName, false);
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

}
