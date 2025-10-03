using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    public int damage;
    [SerializeField] Animator _playerAnimator;
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public bool dontMove = false;
    private Vector2 _moveInput;
    [HideInInspector] public bool facingRight;

    void Awake()
    {
        facingRight = true;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Flip();
    }

    private void FixedUpdate()
    {
        if (!dontMove)
        {
            rb.MovePosition(rb.position + _moveInput * speed * Time.fixedDeltaTime);
        }
        
    }

    void Flip()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        _moveInput = new Vector2(moveX, moveY).normalized;

        _playerAnimator.SetFloat("Speed", _moveInput.sqrMagnitude);


        if (moveX < 0 && facingRight)
        {
            transform.localScale = new Vector3(-0.2f, 0.2f, 0.2f);
            facingRight = false;
        }

        else if (moveX > 0 && !facingRight)
        {
            transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            facingRight = true;
        }
    }

}
