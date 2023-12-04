using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float runSpeed;
    Rigidbody2D rb2;

    public GameObject ParentPlayer;

    private int jumpCount = 0;
    private bool canJump = true;
    Animator anim;

    public float jumpForce;
    private bool stoppedJumping;
    private float jumpTimeCounter;
    public float jumpTime;

    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        anim = ParentPlayer.GetComponent<Animator>();

        jumpTimeCounter = jumpTime;
    }

    void Update()
    {
        FixedUpdate1();

        if (jumpCount == 2) canJump = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Enemy1") || collision.gameObject.CompareTag("Stone") || collision.gameObject.CompareTag("Rock"))
        {
            ResetJump();
        }
    }

    public void Jump()
    {
        if (canJump)
        {
            //rb2.velocity = Vector3.up * jumpSpeed;
            jumpCount += 1;

            StartJump();
        }
    }

    private void ResetJump()
    {
        jumpCount = 0;
        canJump = true;

        StartRun();
    }

    private void StartJump()
    {
        anim.SetBool("startjump", true);
        anim.SetBool("endjump", false);
    }

    private void StartRun()
    {
        anim.SetBool("startjump", false);
        anim.SetBool("endjump", true);
    }

    void FixedUpdate1()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log(canJump);

            if (canJump)
            {
                rb2.velocity = new Vector2(rb2.velocity.x, jumpForce);
                stoppedJumping = false;
                jumpCount++;

                Debug.Log("Jump");
            }
        }

        if (Input.GetKey("space") && !stoppedJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rb2.velocity = new Vector2(rb2.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                stoppedJumping = true;
                jumpTimeCounter = jumpTime;
            }

            //Debug.Log(jumpTimeCounter);
        }


        if (Input.GetKeyUp("space"))
        {
            jumpTimeCounter = 0;
            stoppedJumping = true;
            jumpTimeCounter = jumpTime;
        }
    }
}
