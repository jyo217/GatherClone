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
        //��ũ�� ���� Ŀ�� ��ġ�� ���� ���� ���� ��ġ�� ��ȯ�Ѵ�.
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);

        //�׸��� �����ϴ� ������ �÷��̾� ĳ���Ͱ� Ŀ���� �ٶ󺸴� ������ �ǰ� �Ѵ�.
        newAim = (worldPos - (Vector2)transform.position).normalized;

        //magnitude �� ũ�⸦ �ǹ�. ������ ������ �� ��ü�� ũ�⸦ ������ ��
        if (newAim.magnitude >= .9f)
        {
            CallAimEvent(newAim);
        }
    }
}
