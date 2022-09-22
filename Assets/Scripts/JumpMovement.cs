using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private float jumpforce = 8.0f;
    private Rigidbody2D rigid2D;

    bool isWallJump;

    // Start is called before the first frame update
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(float x)
    {
        rigid2D.velocity = new Vector2(x * speed, rigid2D.velocity.y);
    }

    public void Jump()
    {
        rigid2D.velocity = Vector2.up * jumpforce;


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isWallJump = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        rigid2D.gravityScale = 0.2f;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        rigid2D.gravityScale = 3;
        isWallJump = false;
    }
}
