using UnityEngine;
using System.Collections;
//#include <math.h>

public class wind : MonoBehaviour 
{
	public GUIText output;

	private int 	angle;
	private int 	windState;
	private float	currWSpeed;
	private float 	maxWSpeed;
	private float 	speedInc;
	//private bool 	countDown;
	private Vector3 windDir;

	public const int windUp = 1;
	public const int windDown = -1;
	public const int windOff = 0;

	
	// Use this for initialization
	void Start () 
	{
		//output.text = "Wind Direction X: " + windDir.x.ToString () + ", Z: " + windDir.z.ToString () + ", Speed: " + currWSpeed + " / " + maxWSpeed;
		windState = windOff;
		maxWSpeed = 50;
		//beginWave(100f);
	}
	
	// Update is called once per frame
	void Update () 
	{	
	}

	//Called once per physics step
	void FixedUpdate() 
	{	
		if (windState == windOff) {						//if not currently in wave
		}

		if (windState == windUp) 
		{
			if (currWSpeed >= maxWSpeed)		//if reached max speed
			{
				//windState = windDown;			//stay at max speed
			}
			else 								//otherwise must still be ticking			
			{
				currWSpeed += speedInc;			//increase speed
			}
		}
		if (windState == windDown) 
		{
			if (currWSpeed <= 0)				//if wind completely slowed
			{
				currWSpeed = 0;
				windState = windOff;			//stop wind
			}
			else 								//otherwise must be cooling down
			{
				currWSpeed -= speedInc*4;		//decrease speed
			}
		}

	}

	public void beginWave(float s)
	{
		//setWind (s);
		angle = Random.Range(0, 360);
		maxWSpeed = s;//get from wave timer function
		
		speedInc = maxWSpeed / 1000;
		currWSpeed = 0;
		windState = windUp;

		InvokeRepeating ("updateWind", 1f, 1f);//updatewind
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
		
		float angleRad = angle * Mathf.Deg2Rad;

			foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Gold")) 
			{
				if (obj.constantForce != null) {

					windDir = obj.constantForce.force;

					windDir.x = ((Mathf.Cos(angleRad)) * currWSpeed) * 0.15f;
					windDir.z = ((Mathf.Sin(angleRad)) * currWSpeed) * 0.15f; 
					
					obj.constantForce.force = windDir;					//Gold very slightly affected by wind
				}
			}
		
			foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Debris")) 
			{
				if (obj.constantForce != null) {
				
					windDir = obj.constantForce.force;
				
					windDir.x = ((Mathf.Cos(angleRad)) * currWSpeed) * 0.5f;
					windDir.z = ((Mathf.Sin(angleRad)) * currWSpeed) * 0.5f; 
				
					obj.constantForce.force = windDir;					//Debris dramatically affected by wind
				}
			}


			//Add the wind to a cloth (flag)
			GameObject flagObj = GameObject.FindGameObjectWithTag ("Flag");
			Vector3 flagVec = flagObj.transform.GetComponent<Cloth> ().externalAcceleration;
			flagVec.x = (Mathf.Cos(angleRad) * currWSpeed)*1f;
			flagVec.z = (Mathf.Sin(angleRad) * currWSpeed)*1f; 
			flagObj.transform.GetComponent<Cloth> ().externalAcceleration = flagVec;
		//}

		//output.text = "Wind Direction X: " + windDir.x.ToString () + ", Z: " + windDir.z.ToString () + ", Speed: " + currWSpeed + " / " + maxWSpeed;
		
	}


	public int getWindState()
	{
		return windState;
	}

	public float getMaxWSpeed()
	{
		return maxWSpeed;
	}

	public Vector3 getWindDir()
	{
		return windDir;
	}

	public int getAngle()
	{
		return angle;
	}

	public void setWindStateUp()
	{
		windState = windUp;
	}

	public void setWindStateDown()
	{
		windState = windDown;
	}
		

















}
