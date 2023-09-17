using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBehaviorSetter : MonoBehaviour
{
    [SerializeField] private List<BaseBehavior> behaviorsList;
    [SerializeField] private BaseBehavior currentBehavior;
    [SerializeField] private Components components;

    private enum Behaviors
    {
        Idle,
        Walking
    }
    private Behaviors Behavior
    {
        get { return (Behaviors)components.anim.GetInteger("behavior"); }
        set { components.anim.SetInteger("behavior", (int)value); }
    }


    private void Awake()
    {
        components = GetComponent<Components>();

        behaviorsList = new List<BaseBehavior>()
        {
           GetComponent<IdleSkeletonBehavior>(),
           GetComponent<WalkingSkeletonBehavior>()
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

    public void SetBehaviorWalking()
    {
        var behavior = behaviorsList[(int)Behaviors.Walking];
        Behavior = Behaviors.Walking;
        this.SetBehavior(behavior);
    }

    public void SetBehaviorIdle()
    {
        var behavior = behaviorsList[(int)Behaviors.Idle];
        Behavior = Behaviors.Idle;
        this.SetBehavior(behavior);
    }
}
