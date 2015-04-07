using UnityEngine;
using System.Collections;

public class shootProjectile : MonoBehaviour {


	public Rigidbody projectile;
	public float speed = 20.0f;

	public float distance = 10.0f;


	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Fire1")) {

			Vector3 position;

			position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);

			position = Camera.main.ScreenToWorldPoint(position);

			Rigidbody clone;

			clone = (Rigidbody) Instantiate(projectile,transform.position,transform.rotation);

			clone.transform.LookAt(position);

			Debug.Log (position);

			clone.AddForce(clone.transform.forward * 1000);

			clone.velocity = transform.TransformDirection (Vector3.forward * speed);







		}




		

	
	}
}
