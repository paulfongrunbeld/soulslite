using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IdleSkeletonBehavior : BaseBehavior
{

	[SerializeField] private SkeletonBehaviorSetter skeleton;
	[SerializeField] private float idleTimeInSeconds;
	private System.Random random;

	private void Awake()
	{
		random = new System.Random();
		idleTimeInSeconds = random.Next(1, 4);
		skeleton = GetComponent<SkeletonBehaviorSetter>();
	}
	public override void Enter()
	{
		Invoke("SwitchToWalking", idleTimeInSeconds);
	}

	public override void Exit()
	{
		this.enabled = false;
	}

	private void SwitchToWalking() => skeleton.SetBehaviorWalking();


}
