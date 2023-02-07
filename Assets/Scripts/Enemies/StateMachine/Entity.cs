using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Entity : MonoBehaviour
{
    private Movement Movement { get => movement ??= Core.GetCoreComponent<Movement>(); }

    private Movement movement;

    public EnemyFiniteStateMachine StateMachine { get; private set; }

    public D_Entity entityData;

    public IdleState EnemyIdleState { get; private set; }
    public MoveState EnemyMoveState { get; private set; }
    public Animator Anim { get; private set; }
    public AnimationToStateMachine atsm { get; private set; }
    public Core Core { get; private set; }


    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform ledgeCheck;
    [SerializeField] private Transform playerCheck;

    private float currentHealth;
    private int lastDamageDirection;
    private Vector2 workspace;

    protected bool isStunned;
    protected bool isDead;

    public virtual void Awake()
    {
        Core = GetComponentInChildren<Core>();

        StateMachine = new EnemyFiniteStateMachine();

        currentHealth = entityData.maxHealth;

        Anim = GetComponent<Animator>();
        atsm = GetComponent<AnimationToStateMachine>();

    }

    public virtual void Update()
    {
        Core.LogicUpdate();
        StateMachine.CurrentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    public virtual bool CheckPlayerInMinAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, entityData.minAgroDistance, entityData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInMaxAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, entityData.maxAgroDistance, entityData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInCloseRangeAction()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, entityData.closeRangeActionDistance, entityData.whatIsPlayer);
    }

    public virtual void DamageHop(float velocity)
    {
        workspace.Set(Movement.RB.velocity.x, velocity);
        Movement.RB.velocity = workspace;
    }

    /*public virtual void Damage(AttackDetailsStructure attackDetails)
    {
        currentHealth -= attackDetails.DamageAmount;
        DamageHop(entityData.damageHopSpeed);

        Instantiate(entityData.hitParticle, transform.position, Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));

        if (attackDetails.Position.x > transform.position.x)
        {
            lastDamageDirection = -1;
        }

        else
        {
            lastDamageDirection = 1;
        }

        if (currentHealth <= 0)
        {
            isDead = true;
        }
    }
*/
    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.closeRangeActionDistance), 0.2f);
        Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.minAgroDistance), 0.2f);
        Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.maxAgroDistance), 0.2f);

    }

}
