using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Player : MonoBehaviour
{
    [SerializeField] private List<BaseBehavior> behaviorsList;
    [SerializeField] private BaseBehavior currentBehavior;
    [SerializeField] private Components components;
    

    [SerializeField] public bool isGrounded;

    private enum Behaviors
    {
        Idle,
        Runing,
        Jump,
        Fall,
        Attack
    }
    private Behaviors Behavior
    {
        get { return (Behaviors)components.anim.GetInteger("behavior"); }
        set { components.anim.SetInteger("behavior", (int)value); }
    }


    private void Awake()
    {
        components = GetComponent<Components>();

        isGrounded = true;
      
        behaviorsList = new List<BaseBehavior>()
        {
           GetComponent<IdlePlayerBehavior>(),
           GetComponent<RunningPlayerBehavior>(),
           GetComponent<JumpPlayerBehavior>(),
           GetComponent<FallPlayerBehavior>(),
           GetComponent<AttackPlayerBehavior>()
        };
        SetBehaviorIdle();
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
        var behavior = behaviorsList[(int)Behaviors.Idle];
        Behavior = Behaviors.Idle;
        this.SetBehavior(behavior);
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
        var behavior = behaviorsList[(int)Behaviors.Fall];
        Behavior = Behaviors.Fall;
        this.SetBehavior(behavior);
    }
}
