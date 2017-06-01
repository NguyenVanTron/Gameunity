using UnityEngine;
using System.Collections;


public class Player_Ship : MonoBehaviour 
{
    public float Speed;
    public float FireRate;
    public GameObject Bullet;
    public GameObject Missile;
    public GameObject Ship;
    public Vector2[] BarrelPosition;
    int HP;
    int MissileAmount;
    float lastShootTime;
    Vector2 MoveDirection;
	// Use this for initialization
	void Start () 
    {
        //Debug.Break();
        //Debug.LogError("");
        MoveDirection = new Vector2(0, 0);
        lastShootTime = Time.time;
        //StartCoroutine(Fire());
	}
	
	// Update is called once per frame
	void Update () 
    {
        MoveControl();
        Fire(ref lastShootTime);
	}

    void MoveControl()
    {
        MoveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        MoveDirection *= Speed * Time.deltaTime;
        transform.Translate(MoveDirection.x, MoveDirection.y, 0); // di chuyen 1 khoang theo thoi gian
    }

    void Fire(ref float lastShootTime)
    {
        //Debug.Log("into fire");
        if(Input.GetKey(KeyCode.Space) )
        {
            print(Time.time - lastShootTime);

            if (Time.time - lastShootTime >= FireRate)
            {
                for (int i = 0; i < BarrelPosition.Length; i++)
                {
                    lastShootTime = Time.time;
                    Instantiate(Bullet, transform.position + new Vector3(BarrelPosition[i].x, BarrelPosition[i].y, 0), Quaternion.Euler(0, 0, -90));
                }

            }
        }
    }
}
