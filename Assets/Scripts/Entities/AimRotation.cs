using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer characterRenderer;

    private PlayerInputController controller;

    private void Awake()
    {
        controller = GetComponent<PlayerInputController>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        //컨트롤러에서 마우스의 움직임을 감지했을 때 마다 OnAim 메소드를 호출한다.
        controller.OnAimEvent += Aim;
    }

    public void Aim(Vector2 newAimDirection)
    {
        RotatePlayerDirection(newAimDirection);
    }

    //커서의 좌표를 토대로 캐릭터가 바라보는 방향이 바뀌도록 한다.
    private void RotatePlayerDirection(Vector2 direction)
    {
        //아크 탄젠트를 구하는 공식. 대충 벡터의 각도를 구하는 것이다.
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //커서가 플레이어 캐릭터가 바라보는 방향 기준, 90도 이상의 각도를 이룬다면 플레이어 캐릭터가 반대 방향을 보도록 X 축 기준으로 뒤집는다.
        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;

    }
}
