using UnityEngine;
using System.Collections;

public class debris : MonoBehaviour {

	public GameObject debrisObj;
	public Rigidbody rb;
	public GameObject debrisHolder;

	
	private float hitPoints;
	private float thrust;
	private int spawnCount;

	private int distMultiplier = 70;
	private int angleShift = 20;
	
	// Use this for initialization
	void Start () 
	{
		debrisObj = GameObject.Find("debris");

		rb = GetComponent<Rigidbody>();
		hitPoints = 20.0f;
		//spawnCount = 0;
		thrust = 4000; //get as variable?

	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 pos = this.transform.position;
		if (pos.y <= -2) 
		{
			//Destroy(this);
		}
		
	}

	void FixedUpdate() 
	{
	}
	
	void OnCollisionEnter(Collision col)
	{		
	}
	
	void InitDebris() 
	{
		Vector3 pos = gameObject.transform.position;
		Quaternion rot = gameObject.transform.rotation;
		//Destroy(this.gameObject);
		Instantiate(debrisObj, pos, rot);
	}



	public void throwDebris(int angle)
	{		
		//int angleRad = angle * Mathf.Deg2Rad;
		int spawnAngle = angle + ((int)Mathf.Round(Random.Range (-angleShift, angleShift)));
		//int spawnAngle = angle;
		spawnAngle += 180;
		//int spawnAngle = angle;
		if (spawnAngle >= 360) 
		{
			spawnAngle -= 360;
		}

		Vector3 spawnPos = new Vector3 ();
		spawnPos.x = (Mathf.Cos (spawnAngle * Mathf.Deg2Rad));
		spawnPos.z = (Mathf.Sin (spawnAngle * Mathf.Deg2Rad));
		spawnDebris(spawnPos);

		int throwAngle = angle + ((int)Mathf.Round(Random.Range (-angleShift*1.5f, angleShift*1.5f)));
		//int throwAngle = angle;
		Vector3 throwVec = new Vector3 ();
		throwVec.x = Mathf.Cos (throwAngle * Mathf.Deg2Rad);
		throwVec.z = Mathf.Sin (throwAngle * Mathf.Deg2Rad);

		float vertThrustMultiplier = Random.Range(0.10f, 0.75f);

		rb.AddForce(throwVec.x * thrust, thrust * vertThrustMultiplier, throwVec.z * thrust);
		//rb.AddForce(0, thrust, 0);
	}

	private void spawnDebris(Vector3 spawnPos)
	{
		//Vector3 spawnPos = dir;
		spawnPos.x = (spawnPos.x) * distMultiplier;
		spawnPos.y = 1;
		spawnPos.z = (spawnPos.z) * distMultiplier;

		int debrisType = (int)Mathf.Round (Random.Range (1, 3));	
		switch (debrisType) 
		{
		case 1:
			debrisObj = GameObject.Find ("barrel");
			break;
			
		default:
			debrisObj = GameObject.Find("debris");
			break;
		}
		debrisObj = GameObject.Find ("barrel");

		
		GameObject tmp = Instantiate(debrisObj, spawnPos,  Quaternion.identity) as GameObject;	
		rb = tmp.GetComponent<Rigidbody>();
	}



}
