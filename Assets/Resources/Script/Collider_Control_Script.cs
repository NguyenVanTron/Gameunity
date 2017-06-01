

using UnityEngine;
using System.Collections;

public class Xu_Ly_Va_Cham_Hinh_Cau_A : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {
	}
	void OnCollisionEnter (Collision col1)
	{
		print(gameObject.name + " OnCollisionEnter voi " + col1.gameObject.name);
	}

	void OnTriggerEnter(Collider col2) 
	{
		print(gameObject.name + " OnTriggerEnter voi " + col2.gameObject.name);
	}

	void OnTriggerExit(Collider col2) 
	{
		print(gameObject.name + " OnTriggerExit voi " + col2.gameObject.name);
	}
}
