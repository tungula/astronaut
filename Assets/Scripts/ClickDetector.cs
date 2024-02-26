using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickDetector : MonoBehaviour, IPointerDownHandler, IPointerClickHandler,
    IPointerUpHandler, IPointerExitHandler, IPointerEnterHandler,
    IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public float jumpForce;
    public float jumpTime;
    public GameObject player;

    Rigidbody2D rb2;
    Animator anim;

    //private bool canJump = true;
    //private bool stoppedJumping;
    //private float jumpTimeCounter;
    //private int jumpCount = 0;

    private bool isImageDown = false;

    private PlayerMove playerMove;

    void Start()
    {
        rb2 = player.GetComponent<Rigidbody2D>();
        anim = player.GetComponent<Animator>();
        playerMove = player.GetComponent<PlayerMove>();
        //jumpTimeCounter = jumpTime;
    }

    void Update()
    {
        FixedUpdate1();
        if (playerMove.jumpCount == 1) playerMove.canJump = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("Drag Begin");
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("Dragging");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("Drag Ended");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isImageDown = true;

        if (playerMove.canJump)
        {
            rb2.gravityScale = 2;

            rb2.velocity = new Vector2(rb2.velocity.x, jumpForce);
            playerMove.stoppedJumping = false;
            playerMove.jumpCount++;

            anim.SetBool("IsJumping", true);
            //jumpSound.Play();
        }

        //Debug.Log("Mouse Down: " + eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("Mouse Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("Mouse Exit");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isImageDown = false;

        {
            playerMove.jumpTimeCounter = 0;
            playerMove.stoppedJumping = true;
            playerMove.jumpTimeCounter = jumpTime;

            rb2.gravityScale = 1.5f;
        }

        //Debug.Log("Mouse Up");
    }

    private bool IsImageDown()
    {
        bool res = false;


        return res;
    }

    void FixedUpdate1()
    {
        //if (Input.GetKeyDown("space"))
        //{
        //    if (canJump)
        //    {
        //        rb2.gravityScale = 2;

        //        rb2.velocity = new Vector2(rb2.velocity.x, jumpForce);
        //        stoppedJumping = false;
        //        jumpCount++;

        //        anim.SetBool("IsJumping", true);
        //        //jumpSound.Play();
        //    }
        //}

        if (isImageDown && !playerMove.stoppedJumping)
        {
            if (playerMove.jumpTimeCounter > 0)
            {
                rb2.velocity = new Vector2(rb2.velocity.x, jumpForce);
                playerMove.jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                playerMove.stoppedJumping = true;
                playerMove.jumpTimeCounter = jumpTime;
            }

            //Debug.Log(jumpTimeCounter);
        }


        //if (Input.GetKeyUp("space"))
        //{
        //    jumpTimeCounter = 0;
        //    stoppedJumping = true;
        //    jumpTimeCounter = jumpTime;

        //    rb2.gravityScale = 1.5f;
        //}
    }
}
