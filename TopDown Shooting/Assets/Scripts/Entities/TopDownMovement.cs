using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private TopDownCharacterController _controller;

    private Vector2 _movementDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>(); // ���� ������ �� �ִ� ��Ʈ�ѷ��� ������
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
    }

    private void FixedUpdate() // �������� ó���� ��
    {
        ApplyMovement(_movementDirection);
    }

    private void Move(Vector2 direction)
    {
        _movementDirection = direction;  // Ű���带 �Է��ϸ� direction ���� �����Ƿ�???
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction *= 5;
        _rigidbody.velocity = direction;
    }
}
