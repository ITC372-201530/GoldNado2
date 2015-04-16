using UnityEngine;
using System.Collections;

public class enemyHealth : MonoBehaviour {

	public float health = 100.0f;
	public GameObject bodyObject;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (health <= 0) {
			dead ();
		}

	
	}

	void applyDamage(int damage)
	{
		health = health - damage;
	}

	void dead()
	{
		Destroy (bodyObject);
	}
}
