using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerControl : MonoBehaviour
{
    public float speed = 1;
    public Rigidbody2D rBody;
    public Transform groundCheck;
    public LayerMask groundlayer;

    private float horizontal;
    [SerializeField]
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    

    private void Update()
    {
        rBody.velocity = new Vector2(horizontal * speed, rBody.velocity.y);

        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f )
        {
            Flip();
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rBody.velocity = new Vector2(rBody.velocity.x, jumpingPower);
        }

        if (context.canceled && rBody.velocity.y > 0f)
        {
            rBody.velocity = new Vector2(rBody.velocity.x, rBody.velocity.y * 0.5f);
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundlayer);
        
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }
}
