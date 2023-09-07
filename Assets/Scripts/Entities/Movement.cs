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

    //물리적 연산 처리가 끝난 뒤 호출됨. Update 보다 호출이 좀 더 느리다.
    //Rigidbody 를 이용한 물리적 처리로 이동을 구현하므로 Update 에서 처리할 필요가 없다.
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
        //입력 중인 WASD 방향키가 존재하지 않는다면 '걷기' 애니메이션  => '평상시' 애니메이션 전환 트리거를 활성화한다.
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isWalk", false);
        }
    }

    private void Move(Vector2 direction)
    {
        //방향키 입력 시 '평상시' 애니메이션 => '걷기' 애니메이션 전환 트리거를 활성화한다.
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
