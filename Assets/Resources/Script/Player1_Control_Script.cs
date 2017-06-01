using UnityEngine;
using System.Collections;
/*public enum Animationstatus {
    di,
    dung,
    chot,
    tuyetchieu
}


public class Player1_Control_Script : MonoBehaviour {
    private Animator spriteanima;
    public Animationstatus anima;
    public Animationstatus Anima
    {
        get {
            return anima;
        }
        set {
            anima = value;
        }
    }
    private float moveSpeed;
    private int currenchot;
    private int maxmau;
    private int mau;
	// Use this for initialization
	void Start () {
	    init();
	}
	void init(){
        spriteanima = GetComponent<Animator>();
        moveSpeed = 1.0f;
        currenchot = 0;
        maxmau = 1000;
        mau = maxmau;
        StartCoroutine(ControllerUpdate());

    }
	// Update is called once per frame
	IEnumerator ControllerUpdate () {
	    while(true){

            if (mau <= 0)
            {
                StartCoroutine(Dead());
                yield break;
                //Setanimation("chet");
            }


            if (anima == Animationstatus.dung)
            {
                Setanimation("dung");
            }
            else
            {
                if (anima == Animationstatus.di)
                {
                    Setanimation("di");
                    transform.Translate(Vector3.right * Time.deltaTime);
                }
                else if(anima == Animationstatus.chot){
                        Setanimation("chot");
                        //yield return StartCoroutine(DoDanh());
                }
                else if (anima == Animationstatus.tuyetchieu)
                {
                    Setanimation("tuyetchieu");
                    //yield return StartCoroutine(DoDanh());
                }
            }
           
            yield return null;
        }
	}
    /*IEnumerator DoDanh()
    {
        string attackTrigger = "chot";
        if (currenchot < 3)
        {
            attackTrigger = attackTrigger + (currenchot + 1).ToString();
        }
        yield return StartCoroutine(Setanimatonwait(attackTrigger));
    }
    IEnumerator Setanimatonwait (string clipname){
        if (!spriteanima.GetCurrentAnimatorStateInfo(0).IsName(clipname))
        {
            yield break;
        }
        spriteanima.SetTrigger(clipname);
        float stateDu = spriteanima.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(stateDu);
    }
    IEnumerator Dead()
    {
        yield return StartCoroutine(Setanimatonwait("chet"));
        
        Application.LoadLevel("Fight");
    }
    void Setanimation (string clipname){
        if (!spriteanima.GetCurrentAnimatorStateInfo(0).IsName(clipname))
         {
            spriteanima.SetTrigger(clipname);
        }
    }
}
*/