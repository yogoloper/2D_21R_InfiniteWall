using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Vector2 move;
    public int speed;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //transform.position = new Vector3(move.x, move.y, 0) * speed * Time.deltaTime;
        //transform.Translate(move * speed * Time.deltaTime, Space.Self);

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(move.x * speed, rb.velocity.y);
        //rb.MovePosition(rb.position + move * speed * Time.deltaTime);
        //rb.AddForce(move * speed);
        //rb.AddForce(move * speed, ForceMode2D.Impulse);
    }

    void Flip()
    {
        if (move.x < -0.01f) transform.localScale = new Vector3(-1, 1, 1);
        if (move.x > 0.01f) transform.localScale = new Vector3(1, 1, 1);
    }
}
