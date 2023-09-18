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
        _controller = GetComponent<TopDownCharacterController>(); // 서로 인지할 수 있는 컨트롤러를 가져옴
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
    }

    private void FixedUpdate() // 물리적인 처리를 함
    {
        ApplyMovement(_movementDirection);
    }

    private void Move(Vector2 direction)
    {
        _movementDirection = direction;  // 키보드를 입력하면 direction 값이 들어오므로???
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction *= 5;
        _rigidbody.velocity = direction;
    }
}
