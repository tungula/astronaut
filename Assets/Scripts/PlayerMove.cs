using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed;
    Rigidbody2D rb2;
    public TextMeshProUGUI scoreText;
    public Slider slider;
    public bool move;

    public GameObject PlayerBottom;

    float points = 500f;
    int life = 10;

    private int jumpCount = 0;
    private bool canJump = true;
    Animator anim;

    public float jumpForce;
    private bool stoppedJumping;
    private float jumpTimeCounter;
    public float jumpTime;

    AudioSource jumpSound;

    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        jumpSound = GetComponent<AudioSource>();

        jumpTimeCounter = jumpTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (move) transform.position += Vector3.right * runSpeed * Time.deltaTime;

        if (canJump)
        {
            //jumpTimeCounter = jumpTime;
        }

        points -= 50 * Time.deltaTime;

        slider.value = points / 1000f;

        FixedUpdate1();

        if (jumpCount == 1) canJump = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Enemy1") || collision.gameObject.CompareTag("Stone") || collision.gameObject.CompareTag("Rock"))
        {
            ResetJump();
            anim.SetBool("IsJumping", false);
        }

        if (collision.gameObject.CompareTag("Enemy1") || collision.gameObject.CompareTag("Rock"))
        {
            Kill();
        }

        //Debug.Log(collision.gameObject.name);

        if (collision.gameObject.CompareTag("Oxygen"))
        {
            points += 50;
            Destroy(collision.gameObject);

            scoreText.text = @"Life - " + life;
        }


        if (collision.gameObject.CompareTag("Iron"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Rock"))
        {
            life -= 1;
            scoreText.text = @"Life - " + life;
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
            if (canJump)
            {
                rb2.velocity = new Vector2(rb2.velocity.x, jumpForce);
                stoppedJumping = false;
                jumpCount++;

                anim.SetBool("IsJumping", true);
                //jumpSound.Play();
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

    void Kill()
    {
        //string currentSceneName = SceneManager.GetActiveScene().name;
        //SceneManager.LoadScene(currentSceneName);
    }
}
