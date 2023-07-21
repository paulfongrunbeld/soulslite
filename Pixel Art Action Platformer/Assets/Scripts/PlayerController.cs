using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    // ��������� ������������ ������
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rb;
    private float moveInput;

    private void Awake() => rb = GetComponent<Rigidbody2D>();

    private void Update() => moveInput = Input.GetAxisRaw("Horizontal"); // �������� ���� �� ������
	private void FixedUpdate() => Move(moveInput); // ��������� ������������

	private void Move(float moveInput)
    {
        // ��������� ����� ������� ������
        Vector2 movement = new Vector2(moveInput * moveSpeed * Time.fixedDeltaTime, 0);
        
        rb.velocity += movement; // � ��������� ������, ���������� ������������

    }
}

