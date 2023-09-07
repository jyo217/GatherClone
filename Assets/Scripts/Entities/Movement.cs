using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private PlayerInputController controller;

    private Vector2 movementDirection = Vector2.zero;
    private Rigidbody2D rigidbody;
    private Animator animator;

    private void Awake()
    {
        controller = GetComponent<PlayerInputController>();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    //������ ���� ó���� ���� �� ȣ���. Update ���� ȣ���� �� �� ������.
    //Rigidbody �� �̿��� ������ ó���� �̵��� �����ϹǷ� Update ���� ó���� �ʿ䰡 ����.
    private void FixedUpdate()
    {
        ApplyMovement(movementDirection);
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
    }

    private void Update()
    {
        //�Է� ���� WASD ����Ű�� �������� �ʴ´ٸ� '�ȱ�' �ִϸ��̼�  => '����' �ִϸ��̼� ��ȯ Ʈ���Ÿ� Ȱ��ȭ�Ѵ�.
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isWalk", false);
        }
    }

    private void Move(Vector2 direction)
    {
        //����Ű �Է� �� '����' �ִϸ��̼� => '�ȱ�' �ִϸ��̼� ��ȯ Ʈ���Ÿ� Ȱ��ȭ�Ѵ�.
        animator.SetBool("isWalk", true);
        movementDirection = direction;
        Debug.Log($"Move : {direction}");
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * 5;
        rigidbody.velocity = direction;
    }
}
