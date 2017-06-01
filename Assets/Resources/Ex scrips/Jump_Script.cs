using UnityEngine;
using System.Collections;

public class Jump_Script : MonoBehaviour {
    //public LayerMask playermask;
    Transform mytrans, tag;
    Rigidbody2D mybody;
    //public bool isGround = false;
    float hInput = 0;
    public float speed = 10, jumpVelocity = 10;
    // Use this for initialization
    void Start()
    {
        //init();
        
        mybody = this.GetComponent<Rigidbody2D>();
        mytrans = this.transform;
       // tag = GameObject.Find(this.name + "/GroundCheck").transform; 
    }
    //
    void FixedUpdate()
    {
        Move(Input.GetAxisRaw("Horizontal"));
        //isGround = Physics2D.Linecast(mytrans.position, tag.position, playermask);
        
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        //Move(hInput);
        //isGround = Physics2D.Linecast(mytrans.position, tag.position, playermask);
        //if (hInput == 1 || hInput == -1)
        //{
        //    Move(Input.GetAxisRaw("Horizontal"));
        //}

        //if (hInput == 2 || hInput == -2)
        //{
        //    Move(Input.GetAxis("Vertical"));
        //}
        //if (Input.GetButtonDown("Jump"))
        //{
        //    Jump();
        //}
        //else if(hInput == 1)
        //{
        //    Move(hInput);
        //}
        //else if (hInput == -1)
        //{
        //    Move(hInput);
        //} 
        //else if(hInput == 2){
            
        //    Move2(hInput/2);
        //}
        //else if (hInput == -2)
        //{
        //    Move2(hInput/2);
        //}

    }
    public void Move(float horizontalInput)
    {
        Vector2 moveVel = mybody.velocity;
        moveVel.x = horizontalInput * speed;
        mybody.velocity = moveVel;
    }
    //public void Move2(float horizontalInput)
    //{
    //    Vector2 moveVel = mybody.velocity;
    //    moveVel.y = horizontalInput * speed;
    //    mybody.velocity = moveVel;
    //}
    
    public void Jump()
    {
       // if (isGround)
        //{
            mybody.velocity += jumpVelocity * Vector2.up;
     //  }
    }

    public void StartMoving(float horizontalInput)
    {
        hInput = horizontalInput;
    }
}
