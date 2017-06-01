using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Button_Loadgame : MonoBehaviour {

	// Use this for initialization
    private data_game dieukien;
    int flag;
	void Start () {
        dieukien = new data_game();
        flag = dieukien.read_data("money.gd");

	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void _ChangeScene(string SceneName)
    {
        if(flag > 0)
            SceneManager.LoadScene(SceneName);
    }
}
