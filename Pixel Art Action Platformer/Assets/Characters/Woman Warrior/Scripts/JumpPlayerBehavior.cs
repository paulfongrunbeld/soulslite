using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlayerBehavior : BaseBehavior
{
    [SerializeField] private float jumpForce;

    [SerializeField] private Player player;
    [SerializeField] private Components components;
    [SerializeField] private InputController controller;

    private void Awake()
	{
		jumpForce = 500;
        components = GetComponent<Components>();
        controller = GetComponent<InputController>();
        player = GetComponent<Player>();
    }

    public override void Enter()
    {
        Jump();
        controller.enabled = false;
    }

    public override void Exit()
    {
        controller.enabled = true;
        this.enabled = false;
    } 
    
	public override void Update()
	{
        if (components.rb.velocity.y < 0) 
            player.SetBehaviorFall();
    }

	private void Jump() => components.rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
}
