using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : PlayerCharacterController
{
    private Camera _camera;
    private void Awake()
    {
        _camera = Camera.main;
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);

        Debug.Log($"{value.Get<Vector2>().x}, {value.Get<Vector2>().y}");
    }

    public void OnAim(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        //스크린 상의 커서 위치를 게임 세계 상의 위치로 변환한다.
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);

        //그리고 조준하는 방향은 플레이어 캐릭터가 커서를 바라보는 방향이 되게 한다.
        newAim = (worldPos - (Vector2)transform.position).normalized;

        //magnitude 는 크기를 의미. 조준점 역할을 할 객체의 크기를 설정한 것
        if (newAim.magnitude >= .9f)
        {
            CallAimEvent(newAim);
        }
    }
}
