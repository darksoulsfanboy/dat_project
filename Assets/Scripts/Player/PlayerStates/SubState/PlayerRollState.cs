using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRollState : PlayerAbilityState
{
    public bool CanRoll { get; private set; }

    private Vector2 rollDirecton;
    private float lastRollTime;

    public PlayerRollState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.gameObject.layer = 0;
        rollDirecton = Vector2.right * Movement.FacingDirection;
        Movement?.SetVelocityX(playerData.rollVelocity * rollDirecton.x);
        CanRoll = false;
        isAbilityDone = true;
        player.InputHandler.UseRollInput();
    }

    public override void Exit()
    {
        base.Exit();

        player.gameObject.layer = 6;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Movement?.CurrentVelocity.y < 0.01f)
        {
            stateMachine.ChangeState(player.LandState);
        }
    }

    public bool CheckCanRoll()
    {
        return CanRoll && Time.time > lastRollTime + playerData.rollCooldown;
    }

    public void ResetCanRoll() => CanRoll = true;

}
