using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviorRunning : BaseBehavior
{
    // ѕараметры передвижени€ игрока
    [SerializeField] private float moveSpeed;

    [SerializeField] private Player player;
    [SerializeField] private SpriteRenderer sr;

    // —читываемый с клавиатуры вектор перемещени€
    private float moveInput;
    private Vector3 movement;
    private void Awake()
	{
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        moveSpeed = 0.25f;
	}

	public override void Update()
    {
        TurnCheck();
        Move();
    }

	public override void Exit() => this.enabled = false;

	private void Move()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        // ¬ычисл€ем новую позицию игрока
        movement = new Vector2(moveInput * moveSpeed * Time.fixedDeltaTime, 0);

        // ¬ противном случае, продолжаем передвижение
        player.transform.Translate(movement);

        if (moveInput != 0) player.SetBehaviorRuning();
        else player.SetBehaviorIdle();

    }

    private void TurnCheck()
    {
        if (movement.x < 0) sr.flipX = true;
        else if (movement.x > 0) sr.flipX = false;
    }
    
}

