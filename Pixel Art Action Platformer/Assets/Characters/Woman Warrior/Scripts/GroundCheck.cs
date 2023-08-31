using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private Player player;

	private void Awake() => player = GetComponentInParent<Player>();

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag.Equals("Ground")) player.isGrounded = true;
		player.SetBehaviorRuning();
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag.Equals("Ground")) player.isGrounded = false;
		if (player.rb.velocity.y < 0) player.SetBehaviorFall();
		
	}

}
