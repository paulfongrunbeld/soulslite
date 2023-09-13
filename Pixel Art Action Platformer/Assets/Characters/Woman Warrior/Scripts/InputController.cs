using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
	[SerializeField] private Player player;

	private void Awake() => player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	private void Update()
	{
		if (Input.GetAxisRaw("Horizontal") == 0 && player.isGrounded)
			player.SetBehaviorIdle();
		
		if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && player.isGrounded)
			player.SetBehaviorRuning();

		if (Input.GetKeyDown(KeyCode.Space) && player.isGrounded)
			player.SetBehaviorJump();

		if (Input.GetKeyDown(KeyCode.J) && player.isGrounded)
			player.SetBehaviorAttack();
	}
}
