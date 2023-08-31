using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Player : MonoBehaviour
{
    [SerializeField] private List<BaseBehavior> behaviorsList;
    [SerializeField] private BaseBehavior currentBehavior;
    [SerializeField] private Animator anim;
    [SerializeField] public Rigidbody2D rb;

    [SerializeField] public bool isGrounded;

    private enum Behaviors
    {
        Idle,
        Runing,
        Jump,
        Attack,
        Fall
        
    }

    private Behaviors Behavior
    {
        get { return (Behaviors)anim.GetInteger("behavior"); }
        set { anim.SetInteger("behavior", (int)value); }
    }


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;
        anim = GetComponent<Animator>();
        behaviorsList = new List<BaseBehavior>()
        {
           GetComponent<PlayerBehaviorIdle>(),
           GetComponent<PlayerBehaviorRunning>(),
           GetComponent<PlayerBehaviorJump>(),
           GetComponent<PlayerBehaviorAttack>()
        };
        SetBehavior(behaviorsList[(int)Behaviors.Idle]);
    }

	private void SetBehavior(BaseBehavior newBehavior)
    {
        if (this.currentBehavior != null) this.currentBehavior.Exit();
        this.currentBehavior = newBehavior;
        currentBehavior.enabled = true;
        this.currentBehavior.Enter();
    }
    private void Update()
    {
        if (this.currentBehavior != null) this.currentBehavior.Update();
    }

    public void SetBehaviorRuning()
    {
        
        var behavior = behaviorsList[(int)Behaviors.Runing];
        Behavior = Behaviors.Runing;
        this.SetBehavior(behavior);
    }

    public void SetBehaviorIdle()
    {
        Behavior = Behaviors.Idle;
    }

    public void SetBehaviorAttack()
    {
        var behavior = behaviorsList[(int)Behaviors.Attack];
        Behavior = Behaviors.Attack;
        this.SetBehavior(behavior);
    }

    public void SetBehaviorJump()
    {
        var behavior = behaviorsList[(int)Behaviors.Jump];
        Behavior = Behaviors.Jump;
        this.SetBehavior(behavior);
    }

    public void SetBehaviorFall()
    {
        Behavior = Behaviors.Fall;
    }
}
