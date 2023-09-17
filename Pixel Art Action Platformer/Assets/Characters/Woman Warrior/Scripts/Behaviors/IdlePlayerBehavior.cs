using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlePlayerBehavior : BaseBehavior
{
	[SerializeField] private Navigation navigation;
	
	private void Awake() => navigation = GetComponent<Navigation>();
	public override void Enter() => navigation.enabled = false;
	public override void Exit()
	{
		navigation.enabled = true;
		this.enabled = false;
	}

}
