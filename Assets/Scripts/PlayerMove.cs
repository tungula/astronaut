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
    public bool move;

    public GameObject PlayerBottom;

    public int life = 10;

    public int jumpCount = 0;
    public bool canJump = true;
    Animator anim;

    public float jumpForce;
    public bool stoppedJumping;
    public float jumpTimeCounter;
    public float jumpTime;

    AudioSource jumpSound;

    RoundGenerator cam;

    public Image progressBar;
    private float currentHealth;

    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        jumpSound = GetComponent<AudioSource>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<RoundGenerator>();

        jumpTimeCounter = jumpTime;

        currentHealth = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (move) transform.position += Vector3.right * runSpeed * Time.deltaTime;

        if (canJump)
        {
            //jumpTimeCounter = jumpTime;
        }


        currentHealth -= Time.deltaTime / 50f;

        progressBar.fillAmount = currentHealth;

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
        if (collision.gameObject.CompareTag("StoneDisableJump"))
        {
            anim.SetBool("IsJumping", false);
        }



        if (collision.gameObject.CompareTag("Enemy1") || collision.gameObject.CompareTag("Rock") || collision.gameObject.CompareTag("GroundBottomBorder"))
        {
            Kill();
        }

        //Debug.Log(collision.gameObject.name);

        if (collision.gameObject.CompareTag("Oxygen"))
        {
            currentHealth += 0.1f;
            if (currentHealth > 1) currentHealth = 1;
            Destroy(collision.gameObject);

            scoreText.text = @"Life - " + life;
        }


        if (collision.gameObject.CompareTag("Iron"))
        {
            Destroy(collision.gameObject);
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
        //Debug.Log("Jump is reset");

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
                rb2.gravityScale = 2;

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

            rb2.gravityScale = 1.5f;
        }
    }

    void Kill()
    {
        //string currentSceneName = SceneManager.GetActiveScene().name;
        //SceneManager.LoadScene(currentSceneName);

        life -= 1;
        scoreText.text = @"Life - " + life;

        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 5, gameObject.transform.position.z);

        //cam.RestartGame();
    }
}
