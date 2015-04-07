using UnityEngine;
using System.Collections;
//#include <math.h>

public class wind : MonoBehaviour {
	public GUIText output;

	private int angle;
	private float speed;

	
	// Use this for initialization
	void Start () {
		InvokeRepeating("updateWind", 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void FixedUpdate() {
	
	}
	
	void updateWind() {
		angle = Random.Range(0, 360);

		speed = Random.Range(0f, 1f);
		/*
		Speed begins at 0. Ticks towards 1 over course of the wave (30 secs) then returns to 0 rapidly (not instantaneously)
		Speed slowly winds up before dying down
		Top speed is determined by a multiplier dependant on current wave difficulty.
		 */

		//Change tag to "Blowable" ???
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Gold")) {
			if(obj.constantForce !=null) {

				Vector3 wind = obj.constantForce.force;

				wind.x = Mathf.Cos(angle);
				wind.z = Mathf.Sin(angle); 
					
				obj.constantForce.force = wind;
				output.text ="Wind Direction X: " + wind.x.ToString() +", Z: " + wind.z.ToString() + ", Speed: " + speed;

			}
		}


		//Add the wind to a cloth (flag)
		GameObject flagObj = GameObject.FindGameObjectWithTag ("Flag");
		Vector3 flagVec = flagObj.transform.GetComponent<Cloth> ().externalAcceleration;
		flagVec.x += (speed * 2) * Mathf.Cos(angle);
		flagVec.z += (speed * 2) * Mathf.Sin(angle);
		flagObj.transform.GetComponent<Cloth> ().externalAcceleration = flagVec;

	}
















}
