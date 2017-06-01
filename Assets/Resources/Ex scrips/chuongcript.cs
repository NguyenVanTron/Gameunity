using UnityEngine;
using System.Collections;

public class chuongcript : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(5 * Time.deltaTime, 0, 0);
        if (transform.position.x > 26)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "creepcon")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

    }
}
