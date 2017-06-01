using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Power : MonoBehaviour
{

    public Slider heathbar;
    private int max;
    private int value;
    private data_game rank;
    // Use this for initialization
    void Start()
    {
        rank = new data_game();
        max = 10;
        value = 10;
        rank.write_socer(10, "power.gd");
        rank.write_socer(0, "tichluy.gd");
    }

    // Update is called once per frame
    void Update()
    {
        int test = rank.read_data("mau.gd");
        int tichluy = rank.read_data("tichluy.gd");
        if (tichluy == 10)
        {
            rank.write_socer(10, "power.gd");
            rank.write_socer(0, "tichluy.gd");
        }
        value = rank.read_data("power.gd");
        heathbar.maxValue = max;
        heathbar.value = value;
    }
}
