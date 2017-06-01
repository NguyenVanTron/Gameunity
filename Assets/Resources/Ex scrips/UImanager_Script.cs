using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UImanager_Script : MonoBehaviour {
    public Slider heathbar;
    public Text HPText;
    public Tuong_Control_Script playerheath;
    private data_game rank;
    int mau ;
    int maxmau;
    int damage;
	// Use this for initialization
	void Start () {
        rank = new data_game();
        mau = rank.read_data("mau.gd");
        maxmau = rank.read_data("maxmau.gd");
        damage = rank.read_data("damage.gd");
        playerheath._setmau(mau);
        playerheath._setmaumax(maxmau);
        playerheath._damage(damage);
	}
	
	// Update is called once per frame
	void Update () {
        //if (playerheath._getmau() <= 0)
        //{
         //   Application.LoadLevel("Fight");
       // }
        heathbar.maxValue = maxmau;
        heathbar.value = playerheath._getmau();
        //rank.write_socer(playerheath._getmau(), "mau.gd");
        HPText.text = "HP: " + playerheath._getmau() + "/" + playerheath._getmaxmau();
	}
}
