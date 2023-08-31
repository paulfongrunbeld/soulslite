using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
	[SerializeField] private Player player;

	private void Awake() => player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && player.isGrounded)
		{
			player.SetBehaviorJump();
		}
		if (Input.GetKeyDown(KeyCode.J) && player.isGrounded)
		{
			player.SetBehaviorAttack();
		}
	}
}
