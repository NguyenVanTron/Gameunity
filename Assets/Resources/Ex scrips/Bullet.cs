using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public enum BULLET_TYPE
    {
        Player,
        Enemy,
    }

    public BULLET_TYPE BulletType;
    public float Speed;

	// Update is called once per frame
	void Update () 
    {
        transform.Translate(new Vector3(0, Speed * Time.deltaTime, 0), Space.World);

	}

    void OnDestroy()
    {
    }
    void OnTriggerExit2D(Collider2D Coll)
    {
        if(Coll.gameObject.tag == "BackGround Border" || Coll.gameObject.tag == "Enemy")
        {
           // Debug.Log("On Bullet Destroying");
            Destroy(this.gameObject);
        }
    }

}
