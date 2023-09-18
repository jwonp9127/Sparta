using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownCharacterController
{
    private Camera _camera;
    private void Awake()
    {
        _camera = Camera.main; //메인카메라를 찾아옴
    }

    public void OnMove(InputValue value)
    {
        Debug.Log("OnMove" + value.ToString());
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput); // 이 이동에 대한 정보를 on move event 라는 걸 걸어놓은 애들한테 다 줄 수 있음
    }

    public void OnLook(InputValue value)
    {
        //Debug.Log("OnLook" + value.ToString());
        Vector2 newAim = value.Get<Vector2>();
        // 여기서 우리는 원래 스크린좌표(스크린 상에서의 좌표)로 값을 받았는데 처리는 world 좌표로 해야하므로 변환을 해줘야됨
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim); 
        newAim = (worldPos - (Vector2)transform.position).normalized;  // 여기 잘 아해 안되니까 다시 봐줘

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
