using UnityEngine;
using System.Collections;

public class skillbossss : MonoBehaviour {

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(-5 * Time.deltaTime, 0, 0);
        if (transform.position.x < -26)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "player")
        {

            Destroy(this.gameObject);
        }


    }
}
