using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    // Параметры передвижения игрока
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rb;
    private float moveInput;

    private void Awake() => rb = GetComponent<Rigidbody2D>();

    private void Update() => moveInput = Input.GetAxisRaw("Horizontal"); // Получаем ввод от игрока
	private void FixedUpdate() => Move(moveInput); // Применяем передвижение

	private void Move(float moveInput)
    {
        // Вычисляем новую позицию игрока
        Vector2 movement = new Vector2(moveInput * moveSpeed * Time.fixedDeltaTime, 0);
        
        rb.velocity += movement; // В противном случае, продолжаем передвижение

    }
}

