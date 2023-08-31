using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviorJump : BaseBehavior
{
    // ѕараметры передвижени€ игрока
    [SerializeField] private float moveSpeed;

    [SerializeField] private float jumpForce;

    [SerializeField] private Player player;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] public Rigidbody2D rb;

    // —читываемый с клавиатуры вектор перемещени€
    private float moveInput;
    private Vector3 movement;


    private void Awake()
	{
		jumpForce = 500;
		rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        moveSpeed = 0.25f;
    }

	public override void Enter()
	{
        Jump();
	}

    public override void Exit()
    {
        this.enabled = false;
    }

	public override void Update()
	{
        moveInput = Input.GetAxisRaw("Horizontal");

        // ¬ычисл€ем новую позицию игрока
        movement = new Vector2(moveInput * moveSpeed * Time.fixedDeltaTime, 0);

        // ¬ противном случае, продолжаем передвижение
        player.transform.Translate(movement);

        if (movement.x < 0) sr.flipX = true;
        else if (movement.x > 0) sr.flipX = false;

		if (rb.velocity.y < 0 )
		{
            player.SetBehaviorFall();
		}
    }

	private void Jump() => rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
}
