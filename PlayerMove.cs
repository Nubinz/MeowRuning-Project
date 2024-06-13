using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb;

    public Animator anim;

    public int tocDo = 4;

    public float traiphai;

    public bool isFacingRight = true;

    public bool Nhaymotlan;
    
    private enum MovementState { ngoi, chay, nhay, falling}


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update được gọi mỗi khung hình
    void Update()
    {
        traiphai = Input.GetAxisRaw("Horizontal"); // A = (-1,0); D =(1,0)
        rb.velocity = new Vector2(tocDo * traiphai, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 6f);
            Nhaymotlan = false;
        }

        if(isFacingRight == true && traiphai == -1) // Cột X Scale của nhân vật  = kiểm tra đúng là bên trái và trái == scale X=1.2;
        {                                                 // Lệnh quay trái;
            transform.localScale = new Vector3(-1, 1, 1);
            isFacingRight = false;
        }

        if(isFacingRight == false && traiphai == 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
            isFacingRight = true;
        }

        anim.SetFloat("Dichuyen", Mathf.Abs(traiphai));

    }

    void OnCollisionEnter2D (Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Nhaymotlan = true;
        }
    }

    private void UpdateAnimaionStase()
    {
        MovementState state;

        if (traiphai > 0f)
        {
            state = MovementState.chay;
        }
        else if (traiphai < 0f)
        {
            state = MovementState.chay;
        }
        else
        {
            state = MovementState.ngoi;
        }

        if(rb.velocity.y > 1f)
        {
            state = MovementState.nhay;
        } 
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

}