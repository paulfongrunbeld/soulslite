using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviorRunning : BaseBehavior
{
    // ��������� ������������ ������
    [SerializeField] private float moveSpeed;

    [SerializeField] private Player player;
    [SerializeField] private SpriteRenderer sr;

    // ����������� � ���������� ������ �����������
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

        // ��������� ����� ������� ������
        movement = new Vector2(moveInput * moveSpeed * Time.fixedDeltaTime, 0);

        // � ��������� ������, ���������� ������������
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

