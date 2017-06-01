using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Rank : MonoBehaviour {
    public Text HPText;
    private data_game rank;
    ArrayList score;
	// Use this for initialization
	void Start () {
        rank = new data_game();
        score = rank.read_array("scorelist.gd");
	}
	
	// Update is called once per frame
	void Update () {
        int[] a ;
        a = new int[10];
        string bestscore = "" + "\n";
        int iN = score.Count;
        if (score.Count > 10) { iN = 10; }
        for (int i = 0; i < iN; i++)
        {
            a[i] = (int)score[i];
            if (a[i] > 0)
            {
                bestscore += (i+1) + "................."+ a[0] + "\n" ;

            }
        }
        HPText.text = bestscore;
            
	}
}
