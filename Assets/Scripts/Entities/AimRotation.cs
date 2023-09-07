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
        //��Ʈ�ѷ����� ���콺�� �������� �������� �� ���� OnAim �޼ҵ带 ȣ���Ѵ�.
        controller.OnAimEvent += Aim;
    }

    public void Aim(Vector2 newAimDirection)
    {
        RotatePlayerDirection(newAimDirection);
    }

    //Ŀ���� ��ǥ�� ���� ĳ���Ͱ� �ٶ󺸴� ������ �ٲ�� �Ѵ�.
    private void RotatePlayerDirection(Vector2 direction)
    {
        //��ũ ź��Ʈ�� ���ϴ� ����. ���� ������ ������ ���ϴ� ���̴�.
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //Ŀ���� �÷��̾� ĳ���Ͱ� �ٶ󺸴� ���� ����, 90�� �̻��� ������ �̷�ٸ� �÷��̾� ĳ���Ͱ� �ݴ� ������ ������ X �� �������� �����´�.
        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;

    }
}
