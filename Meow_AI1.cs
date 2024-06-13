using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meow_AI1 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float movespeed = 1f;
    Rigidbody2D MyRigibody;
    BoxCollider2D myBBoxColider;
    bool isFacingRight;
    void Start()
    {
        MyRigibody = GetComponent<Rigidbody2D>();
        myBBoxColider = GetComponent<BoxCollider2D>();
    }
    // Update is called once per frame

 
    void Update()
    {
        if (IsFacingRight())
        {
            MyRigibody.velocity = new Vector2(movespeed, 0f);
        } else
        {
            MyRigibody.velocity = new Vector2(-movespeed, 0f);
        }
    }
     
    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-Mathf.Sign(MyRigibody.velocity.x), transform.localScale.y);
    }
}
