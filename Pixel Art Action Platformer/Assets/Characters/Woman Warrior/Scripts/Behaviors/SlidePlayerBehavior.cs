using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidePlayerBehavior : BaseBehavior
{
	[SerializeField] private Navigation navigation;
	[SerializeField] private InputController controller;
	[SerializeField] private Components components;
	[SerializeField] private float slideForce;

	private void Awake()
	{
		slideForce = 500f;
		navigation = GetComponent<Navigation>();
		controller = GetComponent<InputController>();
		components = GetComponent<Components>();
	}
	public override void Enter()
	{
		navigation.enabled = false;
		controller.enabled = false;
		Slide();
	} 
	public override void Exit()
	{
		Stop();
		navigation.enabled = true;
		controller.enabled = true;
		this.enabled = false;
	}

	private void Slide()
	{
		if (components.sr.flipX)
			components.rb.AddForce(Vector2.left * slideForce);
		else
			components.rb.AddForce(Vector2.right * slideForce);
	}

	private void Stop() => components.rb.velocity = Vector2.zero;
	
}
