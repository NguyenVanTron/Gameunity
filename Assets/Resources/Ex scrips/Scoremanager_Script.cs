using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Scoremanager_Script : MonoBehaviour {
    public Text scoretext;
    public Player_Control_Script player1;
	// Use this for initialization
	void Start () {
        player1.setscore(0);
        player1.setmoney(0);
	}
	
	// Update is called once per frame
	void Update () {
        if (player1.getmoney() == 0 || player1.getscore() == 0 )
        {
            player1.setscore(0);
            player1.setmoney(0);
        }
        scoretext.text = "Score: " + player1.getscore() + "\n" + "Money: " + player1.getmoney();
        if (player1.getscore() > 5000)
        {
            data_game a = new data_game();
            a.write_socer(1000, "mau.gd");
            a.write_socer(100, "damage.gd");
            a.write_socer(1000, "maxmau.gd");
            a.write_socer(player1.getscore(), "scorelist.gd");
            a.write_array(player1.getscore(),"score.gd");
            a.write_socer(player1.getmoney(),"money.gd");
            SceneManager.LoadScene("WinScreen");
        }
	}
}
