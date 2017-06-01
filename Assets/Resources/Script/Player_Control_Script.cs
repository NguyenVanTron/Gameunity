using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Player_Control_Script : MonoBehaviour
{
    private int money;
    private int diem;
    public float speed = 5, jumpVelocity = 10;
    public GameObject Bullet;
    public GameObject skill;
    public float Cooldown;
    float PreShoot;
    public Vector3[] Barrel_Position;
    public Vector3 toado;
    Transform mytrans, tagGround;
    Rigidbody2D mybody;
    public bool isGround = false;
    float hInput = 0;
    public LayerMask playermask;
    private data_game rank;
    // Use this for initialization
    void Start()
    {
        //PreShoot = 0f;
        rank = new data_game();
        rank.write_socer(0,"money.gd");
        //
        rank.write_socer(0, "score.gd");
        setscore(0);
        setmoney(0);
        toado.Set(0.4f,0,0);
        mybody = this.GetComponent<Rigidbody2D>();
        mytrans = this.transform;
        tagGround = GameObject.Find(this.name + "/GroundCheck").transform;

    }
    void FixedUpdate()
    {
        if(getmoney() ==0 || getscore() == 0)
        {
            setscore(0);
            setmoney(0);
        }
        transform.Translate(speed * Time.deltaTime * Input.GetAxis("Horizontal"), speed * Time.deltaTime * Input.GetAxis("Vertical"), 0);
        if (transform.position.x > 9)
        {
            Application.LoadLevel("Play");
            
            //Destroy(this.gameObject);
        }
        isGround = Physics2D.Linecast(mytrans.position, tagGround.position, playermask);
        if (hInput == 1 || hInput == -1)
        {
            Move(Input.GetAxisRaw("Horizontal"));
        }

        if (hInput == 2 || hInput == -2)
        {
            Move(Input.GetAxis("Vertical"));
        }
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        else if (hInput == 1)
        {
            Move(hInput);
        }
        else if (hInput == -1)
        {
            Move(hInput);
        }
        else if (hInput == 2)
        {

            Move2(hInput / 2);
        }
        else if (hInput == -2)
        {
            Move2(hInput / 2);
        }
    }
    public void _ChangeScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
    public void Move(float horizontalInput)
    {
        Vector2 moveVel = mybody.velocity;
        moveVel.x = horizontalInput * speed;
        mybody.velocity = moveVel;
    }
    public void Move2(float horizontalInput)
    {
        Vector2 moveVel = mybody.velocity;
        moveVel.y = horizontalInput * speed;
        mybody.velocity = moveVel;
    }
    public void Jump()
    {
        if (isGround)
        {
            mybody.velocity += jumpVelocity * Vector2.up;
        }
    }
    //void loadman()
    //{
    //    if (diem > 500)
    //    {
    //        Application.LoadLevel("Play");
    //        //_ChangeScene("Fight");
    //    }
    //}
    public void StartMoving(float horizontalInput){
        hInput = horizontalInput;
    }
    public void scoreset(int score)
    {
        diem += score;
    }
    public void moneyset(int money1)
    {
        money += money1;
    }
    public void setscore(int score)
    {
        diem = score;
    }
    public void setmoney(int money1)
    {
        money = money1;
    }
    public int getscore()
    {
        return diem;
    }
    public int getmoney()
    {
        return money;
    }
    public void _OnclickFire()
    {
        Instantiate(Bullet, transform.position + toado, Quaternion.Euler(-1, 0, 0));
    }
    public void _OnclickRocket()
    {
        Instantiate(skill, transform.position + toado, Quaternion.Euler(-1, 0, 0));
    }
    
}