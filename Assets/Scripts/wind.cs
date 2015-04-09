using UnityEngine;
using System.Collections;
//#include <math.h>

public class wind : MonoBehaviour 
{
	public GUIText output;

	private int 	angle;
	private float	currWSpeed;
	private float 	maxWSpeed;
	private float 	speedInc;
	private bool 	countDown;
	private Vector3 windDir;

	
	// Use this for initialization
	void Start () 
	{
		beginWave(100f);
	}
	
	// Update is called once per frame
	void Update () 
	{	
	}

	//Called once per physics step
	void FixedUpdate() 
	{	
		if (countDown) 
		{
			if (currWSpeed >= maxWSpeed)		//if reached max spped
			{
				currWSpeed = 0;
				countDown = false;				//stop countDown
			}
			else 								//otherwise must still be ticking			
			{
				currWSpeed += speedInc;			//increase speed
			}
		}
	}

	void beginWave(float s)
	{
		setWind (s);
		
		speedInc = maxWSpeed / 1000;
		currWSpeed = 0;
		countDown = true;

		InvokeRepeating ("updateWind", 1f, 1f);//updatewind
	}

	void setWind(float s)
	{
		angle = Random.Range(0, 360);		
		//maxSpeed = Random.Range(0f, 10f);//get from wave timer function
		maxWSpeed = s;//get from wave timer function
	}
	
	void updateWind() 
	{
		/*
		Speed begins at 0. Ticks towards 1 over course of the wave (30 secs) then returns to 0 rapidly (not instantaneously)
		Speed slowly winds up before dying down
		Top speed is determined by a multiplier dependant on current wave difficulty.
		 */

		//if (countDown) 
		//{
			//Change tag to "Blowable" ???
			foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Gold")) {
				if (obj.constantForce != null) {

					windDir = obj.constantForce.force;

					windDir.x = (Mathf.Cos (angle) * currWSpeed);
					windDir.z = (Mathf.Sin (angle) * currWSpeed); 
					
					obj.constantForce.force = windDir;
				}
			}


			//Add the wind to a cloth (flag)
			GameObject flagObj = GameObject.FindGameObjectWithTag ("Flag");
			Vector3 flagVec = flagObj.transform.GetComponent<Cloth> ().externalAcceleration;
			flagVec.x =  (Mathf.Cos (angle) * currWSpeed)*0.5f;
			flagVec.z = (Mathf.Sin (angle) * currWSpeed)*0.5f; 
			flagObj.transform.GetComponent<Cloth> ().externalAcceleration = flagVec;
		//}

		output.text = "Wind Direction X: " + windDir.x.ToString () + ", Z: " + windDir.z.ToString () + ", Speed: " + currWSpeed + " / " + maxWSpeed;
		
	}

		

















}
