using UnityEngine;
using System.Collections;

public class Player_Controller : MonoBehaviour {

	// Use this for initialization
    public float NormalSpeed = 38f;
    public float JumpForce = 1600f;
    public GameObject Arm_Gun;


    private float JumpSpeed;
    private float Speed;


    string[] animations = { "isIdle", "isJump", "isRunning" };
    bool grounded;


    private Vector3 localScale;
    protected Animator animator;
    private Vector2 moveDirection;
    float x;

    //change weapons
    
     public GameObject[] weapons; // push your prefabs
 
     public int currentWeapon = 0;
     
     private int nrWeapons;

	void Start () 
    {

        Speed = NormalSpeed;
        JumpSpeed = NormalSpeed * 0.5f;//NormalSpeed * 0.01f;
        GetComponent<Rigidbody2D>().gravityScale = 10;

        localScale = transform.localScale;
        animator = GetComponent<Animator>();
        grounded = true;

         SwitchWeapon(currentWeapon);
         nrWeapons = weapons.Length;
	}
	
	// Update is called once per frame
	void Update () 
    {
        //edit late
        for (int i = 1; i <= nrWeapons; i++)
        {
            if (Input.GetKeyDown("" + i))
            {
                currentWeapon = i - 1;

                SwitchWeapon(currentWeapon);

            }
        }        

        moveDirection = new Vector2(Input.GetAxis("Horizontal"), 0);
        if (moveDirection.x != 0)
        {
            transform.Translate(moveDirection.x * Speed * Time.deltaTime, 0, 0);

        }

        if (moveDirection.x < 0)
        {
            if (localScale.x > 0)
            {

                localScale.x *= -1.0f;
                transform.localScale = localScale;
            }
        }

        if (moveDirection.x > 0)
        {
            if (localScale.x < 0)
            {

                localScale.x *= -1.0f;
                transform.localScale = localScale;
            }
        }
        if (grounded)
        {

            Speed = NormalSpeed;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                //rigidbody2D.velocity = new Vector2(0, JumpForce);
                //oveDirection.y = JumpForce;
                //rigidbody2D.AddForce(new Vector2(0, JumpForce));

                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpForce));

            } 
            if (moveDirection.x == 0)
            {
                resetAllTrigger();
                animator.SetTrigger("isIdle");
            }
            else
            {
                resetAllTrigger();
                animator.SetTrigger("isRunning");
            }
        }
        else
        {
            Speed = JumpSpeed;
            resetAllTrigger();
            animator.SetTrigger("isJump");
        }


	}
    void FixUpdate()
    {
        
        
    }
    void LateUpdate()
    {
        Vector3 deffrence = Camera.main.ScreenToWorldPoint(Input.mousePosition) -Arm_Gun.transform.position;
        float rotz;

        rotz = Mathf.Atan2(deffrence.y, deffrence.x) * Mathf.Rad2Deg;
        if (localScale.x < 0)
        {

            //rotz = Mathf.Atan2(deffrence.y, deffrence.x) * Mathf.Rad2Deg;
            Arm_Gun.transform.localRotation = Quaternion.Euler(0, 0, 360 - rotz);
            //deffrence = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Arm_Gun.transform.position;
            //Arm_Gun.transform.localScale = new Vector3(-Arm_Gun.transform.localScale.x, -Arm_Gun.transform.localScale.y, Arm_Gun.transform.localScale.z);
           // Arm_Gun.transform.rotation = Quaternion.Euler(0, 0, rotz - 180);
            Arm_Gun.transform.localScale = new Vector3(localScale.x, -localScale.y, localScale.z);
        }
        else 
        {

            Arm_Gun.transform.localScale = new Vector3(localScale.x, localScale.y, localScale.z);
            Arm_Gun.transform.localRotation = Quaternion.Euler(0, 0, rotz);
        }
           // rotz = Mathf.Atan2(deffrence.y, deffrence.x) * Mathf.Rad2Deg;



        //transform.Translate(0, 0, rotz);
    }
    void OnCollisionStay2D(Collision2D Ground)
    {
        if (Ground.gameObject.tag == "Ground")
        {

            grounded = true;
            //if (animator.GetBool("isJump") == true)
            //{
            //    animator.SetBool("isIdle", true);
            //}

        }
        
    }
    void OnCollisionExit2D(Collision2D Ground)
    {
        if (Ground.gameObject.tag == "Ground")
        {
            grounded = false;
            //  animator.SetTrigger("isJump");

        }
    }
    void resetAllTrigger()
    {
        for(int i = 0; i < animations.Length; i++)
        {
            animator.ResetTrigger(animations[i]);
        }
    }

    void SwitchWeapon(int index)
    {

        for (int i = 0; i < nrWeapons; i++)
        {
            if (i == index)
            {
                weapons[i].gameObject.SetActive(true);
            }
            else
            {
                weapons[i].gameObject.SetActive(false);
            }
        }
    }
}








//if (Input.GetKey(KeyCode.RightArrow))
//{
//    character.transform.Translate(VSpeed * Time.deltaTime);
//    animator.SetBool("isRunning", true);
//}
//if (Input.GetKey(KeyCode.LeftArrow))
//{
//    character.transform.Translate(-VSpeed * Time.deltaTime);
//    animator.SetBool("isRunning", true);
//}


//if (Input.GetKeyDown(KeyCode.LeftArrow) && grounded)
//{
//        animator.SetBool("isIdle", false);
//        animator.SetBool("isRunning", true);
//    if (localScale.x > 0)
//    {

//        localScale.x *= -1.0f;
//        transform.localScale = localScale;
//    }
//}
//if (Input.GetKeyDown(KeyCode.RightArrow) && grounded)
//{
//        animator.SetBool("isIdle", false);
//        animator.SetBool("isRunning", true);
//    if(localScale.x < 0)
//    {
//        localScale.x *= -1.0f;
//        transform.localScale = localScale;
//    }
//   // SpriteRotation.localRotation = Quaternion.Euler(0, 0, 0);
//}

//if (Input.GetKeyUp(KeyCode.LeftArrow))// || Input.GetKeyUp(KeyCode.RightArrow))
//{
//    if (animator.GetBool("isRunning") == true)
//    {
//        if(localScale.x<0)
//        {
//            animator.SetBool("isRunning", false);
//            animator.SetBool("isIdle", true);

//        }
//    }
//}
//if (Input.GetKeyUp(KeyCode.RightArrow))// || Input.GetKeyUp(KeyCode.RightArrow))
//{
//    if (animator.GetBool("isRunning") == true)
//    {
//        if (localScale.x >= 0)
//        {
//            animator.SetBool("isRunning", false);
//            animator.SetBool("isIdle", true);

//        }
//    }
//}

//if (animator.GetBool("isRunning") == true)
//{
//    if (localScale.x > 0)
//    {

//        //transform.Translate(Speed * Time.deltaTime, 0, 0);
//        rigidbody2D.velocity = new Vector2(Speed, 0);
//    }
//    else
//    {
//        //transform.Translate(-Speed * Time.deltaTime, 0, 0);
//        //rigidbody2D.AddForce(new Vector2(-Speed, 0), ForceMode2D.Impulse);

//        rigidbody2D.velocity = new Vector2(-Speed, 0);
//    }
//}



//if (Input.GetKeyDown(KeyCode.UpArrow))
//{
//    if(grounded)
//    {

//        animator.SetBool("isIdle", false);
//        animator.SetBool("isRunning", false);
//        animator.SetTrigger("isJump");
//        rigidbody2D.AddForce(Vector2.up * 3000f);

//        rigidbody2D.AddForce(Vector2.right * 3000f);
//    }

//    // SpriteRotation.localRotation = Quaternion.Euler(0, 0, 0);
//}
