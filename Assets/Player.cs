using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MoveSpeed;
    public float Jump;

    public LayerMask ground;

    public GameObject player;

    Collider2D col;
    Rigidbody2D rb;

    Animator anim;
    bool isGround;

    bool isRight; 
    bool isLeft;
    bool isUp;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponentInChildren<Collider2D>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isRight)
        {
            transform.Translate(Vector2.right * 1 * MoveSpeed * Time.deltaTime);
            anim.SetBool("isRun", true);
            player.transform.localScale = new Vector2(1.265983f, 1f);
        }
        if(isLeft)
        {
            transform.Translate(Vector2.right * -1 * MoveSpeed * Time.deltaTime);
            anim.SetBool("isRun", true);
            player.transform.localScale = new Vector2(-1.265983f, 1f);
        }
        if(isUp)
        {
            anim.SetBool("isRun", false);
        }

        //Move
        float horizontal = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector2.right * horizontal * MoveSpeed * Time.deltaTime);

        if(horizontal !=0)
        {
            if(horizontal < 0)
            {
                player.transform.localScale = new Vector2(-1.265983f, 1f); //ganti ukuran (12345f) kalo misalnya ganti ukuran gambar
            }
            else if(horizontal > 0)
            {
                player.transform.localScale = new Vector2(1.265983f, 1f);
            }
            anim.SetBool("isRun", true);
        }
        else if(horizontal == 0 || isGround == false)
        {
            anim.SetBool("isJump", true);
        }

        //Jump
        isGround = col.IsTouchingLayers(ground);

        if(isGround && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * Jump);
        }

        if(!isGround)
        {
            anim.SetBool("isRun", false);
            anim.SetBool("isJump", true);
        }
        else
        {
            anim.SetBool("isJump", false);
        }
    }

    public void leftButton()
    {
        isLeft = true;
        isRight = false;
        isUp = false;
    }
    public void rightButton()
    {
        isLeft = false;
        isRight = true;
        isUp = false;
    }

    public void upButton()
    {
        isLeft = false;
        isRight = false;
        isUp = true;
    }

    public void jumpButton()
    {
        anim.SetBool("isJump", true);
        rb.AddForce(Vector2.up * Jump);
    }

}
