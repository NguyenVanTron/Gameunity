using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Movecontroller : MonoBehaviour {

    //public Animationstatus statu;
    
    public void _OnclickLeft()
    {
        //transform.Translate(5 * Time.deltaTime * Input.GetAxis("Horizontal"), 5 * Time.deltaTime * Input.GetAxis("Vertical"), 0);
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0f, 0f) * Time.deltaTime );
        /*GameObject player = GameObject.FindGameObjectWithTag("Player");
        Tuong_Control_Script controller = player.GetComponent<Tuong_Control_Script>();
        controller.Anima = statu;*/
    }
    public void _OnclickRight()
    {
        transform.Translate(Vector3.right * 5);
    }
    public void _OnclickUp()
    {
        transform.Translate(Vector3.up * 5);
    }
    public void _OnclickDown()
    {
        transform.Translate(Vector3.down * 5);
    }
    
}
