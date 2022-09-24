using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    float h;
    public float speed;
    Rigidbody2D rb;

    public float jumpForce;
    public Transform groudCheck;
    public LayerMask groundLayer;

    bool isGrounded;
    bool jump;

    [Header("Opposit Jump System")]


    [Header("Wall Jump System")]
    public Transform wallCheck;
    bool isWallTouch;
    bool isSliding;
    public float wallSlidingSpeed;
    public float wallJumpDuration;
    public Vector2 wallJumpForce;
    bool wallJumping;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("LeftJump");
            //jump = true;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("RightJump");
            //jump = true;
        }

        isGrounded = Physics2D.OverlapBox(groudCheck.position, new Vector2(0.8f, 0.2f), 0, groundLayer);
        isWallTouch = Physics2D.OverlapBox(wallCheck.position, new Vector2(0.2f, 0.8f), 0, groundLayer);

        if(isWallTouch && !isGrounded)
        {
            isSliding = true;
        }
        else
        {
            isSliding = false;
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(h * speed, rb.velocity.y);

        if (jump)
        {
            Jump();
        }

        if (isSliding)
        {
            //rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * wallSlidingSpeed);

            Debug.Log("Sliding");
        }

        if (wallJumping)
        {
            rb.velocity = new Vector2(-h * wallJumpForce.x, wallJumpForce.y);
        }
        else
        {
            rb.velocity = new Vector2(h * speed, rb.velocity.y);
        }
    }

    void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        else if(isSliding)
        {
            wallJumping = true;
            Invoke("StopWallJump", wallJumpDuration);
        }

        jump = false;
    }

    void LeftJump()
    {
        wallJumping = true;
        Invoke("StopWallJump", wallJumpDuration);

        jump = false;
    }

    void RightJump()
    {
        wallJumping = true;
        Invoke("StopWallJump", wallJumpDuration);

        jump = false;
    }

    void StopWallJump()
    {
        wallJumping = false;
    }

    void Flip()
    {
        if (h < -0.01f) transform.localScale = new Vector3(-1, 1, 1);
        if (h > 0.01f) transform.localScale = new Vector3(1, 1, 1);
    }

}
