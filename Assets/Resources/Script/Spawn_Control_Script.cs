using UnityEngine;
using System.Collections;
public class Spawn_Control_Script : MonoBehaviour
{
    public float dichBegin;
    public float dichDelay;
    public GameObject dich;

    // Use this for initialization
    void Start()
    {
        dichBegin = Random.Range(3f, 5f);
        dichDelay = Random.Range(3f, 5f);
        InvokeRepeating("SpawnDich", dichBegin, dichDelay);

    }
    // Update is called once per frame
    void Update()
    {
        /*transform.Translate(0, -2* Time.deltaTime, 0, Space.World);
        if (transform.position.y < -8)
        {
            Destroy(this.gameObject);
        }*/
    }
    void SpawnDich()
    {
        Instantiate(dich, transform.position, transform.rotation);
    }

}