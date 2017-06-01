using UnityEngine;
using System.Collections;

public class History_Script : MonoBehaviour {
    private Rigidbody2D myRigibody;
    private bool moving;
    public float timeBetWeenMove;
    private float timebetweencounter;
    public float timetomove;
    private float timetomovecounter;
    private Vector3 moveDirection;
    public float waittoreload;
    private bool reloading;
    private GameObject thegame;
    public Animator animaboss;
    public int mau = 5000;
    public int maumax = 5000;
    public int damage = 0;
    public GameObject skill;
    public Tuong_Control_Script playerrr;
    public Vector3 toado;
    Transform mytrans;
    Rigidbody2D mybody;
    public float speed = 10, jumpVelocity = 10;
	// Use this for initialization
	void Start () {
        
        mybody = this.GetComponent<Rigidbody2D>();
        mytrans = this.transform;
        myRigibody = GetComponent<Rigidbody2D>();
        animaboss = GetComponent<Animator>();
        toado.Set(7.02f, 0.32f, 0);
        timebetweencounter = timeBetWeenMove;
        timetomovecounter = timetomove;
        timebetweencounter = Random.Range(timeBetWeenMove * 0.75f, timeBetWeenMove * 1.25f);
        timetomovecounter = Random.Range(timetomove * 0.75f, timeBetWeenMove * 1.25f);
        }
	
	// Update is called once per frame
	void Update () {
        if (mau == 0)
        {
            Application.LoadLevel("Win2");
        }
        if (moving)
        {
            timetomovecounter -= Time.deltaTime;
            myRigibody.velocity = moveDirection;
            if (timetomovecounter < 0f)
            {
                moving = false;
                //timetomovecounter = timeBetWeenMove;
                timebetweencounter = Random.Range(timeBetWeenMove * 0.75f, timeBetWeenMove * 1.25f);
            }
        }
        else
        {
            timebetweencounter -= Time.deltaTime;
            myRigibody.velocity = Vector2.zero;
            if (timebetweencounter < 0f)
            {
                moving = true;
                //timetomovecounter = timetomove;
                timetomovecounter = Random.Range(timetomove * 0.75f, timeBetWeenMove * 1.25f);
                moveDirection = new Vector3(Random.Range(-1f, 1f), 0f, 0f);
            }
        }
        if (reloading)
        {
            waittoreload -= Time.deltaTime;
            if (waittoreload < 0)
            {
                Application.LoadLevel(Application.loadedLevel);
                thegame.SetActive(true);
            }
        }
	}
    public void jump()
    {
        if(transform.position.y < -1.2)
            mybody.velocity += jumpVelocity * Vector2.up;
    }
    public void Move(float horizontalInput)
    {
        Vector2 moveVel = mybody.velocity;
        moveVel.x = horizontalInput * speed;
        mybody.velocity = moveVel;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        data_game a = new data_game();
        int damagetuong = a.read_data("damage.gd");
        if (other.tag == "player2")
        {
            if (mau > 0)
                mau -= damagetuong;//playerrr._getdamage();
            if (mau < 0)
                mau = 0;
            animaboss.SetTrigger("Chat");
            animaboss.StopRecording();
            //Destroy(other.gameObject);
            //other.gameObject.SetActive(false);
            //reloading = true;
            //thegame = other.gameObject;
        }
        if (other.tag == "dan")
        {
            //animaboss.SetTrigger("Skill2");

            if (mau > 0)
                mau -= damagetuong;//playerrr._getdamage()*2;
            if (mau < 0)
                mau = 0;
            //animaboss.SetTrigger("Skill");
            //animaboss.StopRecording();
            Destroy(other.gameObject);
            if (mau < 500)
            {
                //animaboss.SetTrigger("Skill2");
                Instantiate(skill, transform.position + toado, Quaternion.Euler(0, -1, 0));
            }
            //other.gameObject.SetActive(false);
            //reloading = true;
            //thegame = other.gameObject;
        }
    }
}
