using UnityEngine;
using System.Collections;
public class Bullet_Control_Script : MonoBehaviour
{
    public GameObject player;
    //public int diem;
    //public int money;
    // Use this for initialization
    void Start()
    {
        //money = player.GetComponent<Player_Control_Script>().getmoney() ;
        //diem = player.GetComponent<Player_Control_Script>().getscore() ;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(5 * Time.deltaTime, 0, 0);
        if (transform.position.x > 9)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "creep")
        {
            //other.gameObject.GetComponent<QLdiemtien>().moneyset(50);
            //other.gameObject.GetComponent<QLdiemtien>().scoreset(10);
           // if (player.CompareTag("player"))
           // {
            player.GetComponent<Player_Control_Script>().moneyset(100);
            player.GetComponent<Player_Control_Script>().scoreset(100);
           // }
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

    }
}