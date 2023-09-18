using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownCharacterController
{
    private Camera _camera;
    private void Awake()
    {
        _camera = Camera.main; //����ī�޶� ã�ƿ�
    }

    public void OnMove(InputValue value)
    {
        Debug.Log("OnMove" + value.ToString());
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput); // �� �̵��� ���� ������ on move event ��� �� �ɾ���� �ֵ����� �� �� �� ����
    }

    public void OnLook(InputValue value)
    {
        //Debug.Log("OnLook" + value.ToString());
        Vector2 newAim = value.Get<Vector2>();
        // ���⼭ �츮�� ���� ��ũ����ǥ(��ũ�� �󿡼��� ��ǥ)�� ���� �޾Ҵµ� ó���� world ��ǥ�� �ؾ��ϹǷ� ��ȯ�� ����ߵ�
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim); 
        newAim = (worldPos - (Vector2)transform.position).normalized;  // ���� �� ���� �ȵǴϱ� �ٽ� ����

        if(newAim.magnitude >= .9f)
        {
            CallLookEvent(newAim);
        }
    }

    public void OnFire(InputValue value)
    {
        IsAttacking = value.isPressed;
    }
}
