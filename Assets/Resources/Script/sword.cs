using UnityEngine;
using System.Collections;

public class sword : MonoBehaviour {

	// Use this for initialization
    public Tuong_Control_Script playerheath;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "player")
        {
            //Destroy(this.gameObject);
            if (playerheath._getmau() > 0)
                playerheath._mau(-100);
            if (playerheath._getmau() < 0)
                playerheath._setmau(0);
            //Destroy(other.gameObject);

        }
    }
}
