using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayerBehavior : BaseBehavior
{
	[SerializeField] private Navigation navigation;
	[SerializeField] private InputController controller;

	private void Awake()
	{
		navigation = GetComponent<Navigation>();
		controller = GetComponent<InputController>();
	}
	public override void Enter()
	{
		navigation.enabled = false;
		controller.enabled = false;
	}
	public override void Exit()
	{
		navigation.enabled = true;
		controller.enabled = true;
		this.enabled = false;
	} 
}
