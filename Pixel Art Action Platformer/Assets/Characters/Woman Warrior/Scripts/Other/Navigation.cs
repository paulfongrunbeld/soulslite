using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour
{
	// ѕараметры передвижени€ игрока
	[SerializeField] private float moveSpeed;
	// —читываемый с клавиатуры вектор перемещени€
	private float moveInput;
	private Vector3 movement;

	[SerializeField] private Components components;

	private void Awake()
	{
		components = GetComponent<Components>();
		moveSpeed = 0.25f;
	}

	private void Move()
	{
		moveInput = Input.GetAxisRaw("Horizontal");

		// ¬ычисл€ем новую позицию игрока
		movement = new Vector2(moveInput * moveSpeed * Time.fixedDeltaTime, 0);

		// ¬ противном случае, продолжаем передвижение
		transform.Translate(movement);
	}

	private void CheckRoatation()
	{
		if (movement.x < 0) components.sr.flipX = true;
		else if (movement.x > 0) components.sr.flipX = false;
	}

	private void Update()
	{
		Move();
		CheckRoatation();
	}
}
