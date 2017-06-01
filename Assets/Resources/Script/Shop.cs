using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Shop : MonoBehaviour {
    public Text moneytext;
    public Text moneysadad;
    public Player_Control_Script player1;
    public Tuong_Control_Script pl2;
    private data_game rank;
    public int money;
    public int mau = 1000;
    public int damage = 500;
    public int maxmau = 1000;
	// Use this for initialization
	void Start () {
        rank = new data_game();
        money = rank.read_data("money.gd");
        mau = rank.read_data("mau.gd");
        damage = rank.read_data("damage.gd");
       // player1.moneyset(player1.getmoney());
	}
	
	// Update is called once per frame
	void Update () {

        moneytext.text = "" + damage + "\n\n"+ mau;
        moneysadad.text = "" + money;
	}
    public void _muamau()
    {
        if (money >= 500)
        {
            //pl2._mau(1000);
            //pl2._maumax(1000);
            mau += 1000;
            maxmau += 1000;
            money -= 500;
            rank.write_socer(mau, "mau.gd");
            rank.write_socer(maxmau, "maxmau.gd");
            rank.write_socer(money, "money.gd");
            //player1.moneyset(-500);
        }
    }
    public void _muadame()
    {
        if (money >= 500)
        {
            //pl2._damage(500);
            damage += 500;
            money -= 500;
            rank.write_socer(damage, "damage.gd");
            rank.write_socer(money, "money.gd");
            //player1.moneyset(-500);
        }
    }
    //public void _ChangeScene(string SceneName)
    //{
    //    SceneManager.LoadScene(SceneName);
    //}
}
