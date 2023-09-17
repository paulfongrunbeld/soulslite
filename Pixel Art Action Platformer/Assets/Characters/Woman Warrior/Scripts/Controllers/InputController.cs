using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
	[SerializeField] private PlayerBehaviorSetter player;
	[SerializeField] private Components components;

	private void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviorSetter>();
		components = GetComponent<Components>();
	} 
	private void Update()
	{
		if (Input.GetAxisRaw("Horizontal") == 0 && player.isGrounded)
			player.SetBehaviorIdle();

		if (components.rb.velocity.y < 0 && !player.isGrounded)
			player.SetBehaviorFall();

		if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && player.isGrounded)
			player.SetBehaviorRuning();

		if (Input.GetKeyDown(KeyCode.Space) && player.isGrounded)
			player.SetBehaviorJump();

		if (Input.GetKeyDown(KeyCode.J) && player.isGrounded)
			player.SetBehaviorAttack();

		if (Input.GetKeyDown(KeyCode.K) && player.isGrounded)
			player.SetBehaviorSlide();
	}
}
