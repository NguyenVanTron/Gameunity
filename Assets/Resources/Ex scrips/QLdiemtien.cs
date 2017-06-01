using UnityEngine;
using System.Collections;

public class QLdiemtien : MonoBehaviour {

    public int tien=0;
    public int diem=500;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
    public void scoreset(int score)
    {
        diem += score;
    }
    public void moneyset(int money1)
    {
        tien += money1;
    }
    public void setdiem2()
    {
        diem = 0;
    }
}
