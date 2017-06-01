using UnityEngine;
using System.Collections;

public class Lohong : MonoBehaviour
{
    public GameObject player;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-6 * Time.deltaTime,0 , 0);
        if (transform.position.x < -9)
        {
            Destroy(this.gameObject);
        }


    }
    void OnTriggerExit2D(Collider2D other)
    {
        if ( other.tag == "dich")
        {
            Destroy(other.gameObject);
        }
        if (other.tag == "player")
        {
            player.GetComponent<Player_Control_Script>().setmoney(0);
            player.GetComponent<Player_Control_Script>().setscore(0);
            Application.LoadLevel("Play");
            

        }

    }
}
