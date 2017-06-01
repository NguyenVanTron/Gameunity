using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UImanagerBoss : MonoBehaviour {

    public Slider heathbar;
    public Text HPText;
    public History_Script playerheath;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        heathbar.maxValue = playerheath.maumax;
        heathbar.value = playerheath.mau;
        HPText.text = "HP: " + playerheath.mau + "/" + playerheath.maumax;
    }
}
