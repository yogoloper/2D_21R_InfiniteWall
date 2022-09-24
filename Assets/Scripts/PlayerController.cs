using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private JumpMovement jumpMovement;
    // Start is called before the first frame update


    [Header("Wall Jump System")]
    public Transform wallCheck;
    bool isWallTouch;
    bool isSliding;
    public float wallSlidingSpeed;

    void Start()
    {
        jumpMovement = GetComponent<JumpMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        jumpMovement.Move(x);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpMovement.Jump();
        }
        
    }
}
