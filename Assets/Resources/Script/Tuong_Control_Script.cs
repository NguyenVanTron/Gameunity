using UnityEngine;
using System.Collections;
public class Tuong_Control_Script : MonoBehaviour {
    public GameObject chuong;
    public Animator anima;
    
    Transform mytrans, tagGround;
    Rigidbody2D mybody;
    public bool isGround = false;
    float hInput = 0;
    public float speed = 10, jumpVelocity = 10;
    public LayerMask playermask;
   
    public int mau = 1000;
    private int maumax = 1000;
    private int damage = 100;
    public Vector3 toado;
    public bool ani = false;
    // Use this for initialization
    void Start()
    {
        //init();
        anima = GetComponent<Animator>();
        toado.Set(1.42f, 0.28f, 0);
        mybody = this.GetComponent<Rigidbody2D>();
        mytrans = this.transform;
        tagGround = GameObject.Find(this.name + "/GroundCheck").transform; 
    }
    //
    void FixedUpdate()
    {
        isGround = Physics2D.Linecast(mytrans.position, tagGround.position, playermask);
        Move(Input.GetAxisRaw("Horizontal"));
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        Move(hInput);
        if (mau <= 0)
        {
            data_game a = new data_game();
            mau = a.read_data("mau.gd");
            Application.LoadLevel("Fight");
        }
        //anima.StopRecording();
    }
    public void _Onclickchuong()
    {
        anima.SetTrigger("Chem");
        data_game a = new data_game();
        int power = a.read_data("power.gd");
        if (power > 0)
        {
            Instantiate(chuong, transform.position + toado, Quaternion.Euler(0, 0, 0));
            a.write_socer(power-1, "power.gd");
        }
    }
    public void Move(float horizontalInput)
    {
        Vector2 moveVel = mybody.velocity;
        moveVel.x = horizontalInput * speed;
        mybody.velocity = moveVel;
    }
    public void Jump()
    {
        if (transform.position.y < -1.331772)
        {
            mybody.velocity += jumpVelocity * Vector2.up;
        }
    }
    public void StartMoving(float horizontalInput)
    {
        hInput = horizontalInput;
    }
    public void _Rightanimation()
    {
        anima.SetTrigger("Right");
        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "creepcon")
        {
            data_game a = new data_game();
            int dangco = a.read_data("tichluy.gd");
            a.write_socer(dangco + 1, "tichluy.gd");
            if(mau > 0)
                mau -= 100;
            if (mau < 0)
                mau = 0;
            Destroy(other.gameObject);
            
        }
        if (other.tag == "creep")
        {
            data_game a = new data_game();
            int dangco = a.read_data("tichluy.gd");
            a.write_socer(dangco + 1, "tichluy.gd");
            if (mau > 0)
                mau -= 100;
            if (mau < 0)
                mau = 0;
            //Destroy(other.gameObject);

        }
        if (other.tag == "sword")
        {
            if (mau > 0)
                mau -= 100;
            if (mau < 0)
                mau = 0;
            //Destroy(other.gameObject);

        }
    }
    public void _damage(int dama)
    {
        damage += dama;
    }
    public void _mau(int mauuu)
    {
        mau += mauuu;
    }
    public void _setmau(int mauuu)
    {
        mau = mauuu;
    }
    public void _maumax(int mauuu)
    {
        maumax += mauuu;
    }
    public void _setmaumax(int mauuu)
    {
        maumax = mauuu;
    }
    public int _getdamage()
    {
        return damage;
    }
    public int _getmau()
    {
        return mau;
    }
    public int _getmaxmau()
    {
        return maumax;
    }
}
