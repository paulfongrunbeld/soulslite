using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private PlayerBehaviorSetter player;
	[SerializeField] private Components components;

	private void Awake()
	{
		player = GetComponentInParent<PlayerBehaviorSetter>();
		components = GetComponent<Components>();
	} 

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag.Equals("Ground")) player.isGrounded = true;
		player.SetBehaviorIdle();
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag.Equals("Ground")) player.isGrounded = false;
	}

}
