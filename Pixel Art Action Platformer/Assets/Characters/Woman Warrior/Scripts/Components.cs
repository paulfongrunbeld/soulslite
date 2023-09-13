using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Components : MonoBehaviour
{
    [SerializeField] public SpriteRenderer sr;
    [SerializeField] public Rigidbody2D rb;
	[SerializeField] public Animator anim;
	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
	}
}
