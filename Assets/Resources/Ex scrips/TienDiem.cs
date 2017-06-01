using UnityEngine;
using System.Collections;

public class TienDiem : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-2 * Time.deltaTime, 0, 0);
        if (transform.position.x < -25)
        {
            Destroy(this.gameObject);
        }


    }

}