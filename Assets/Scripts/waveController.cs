using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class waveController : MonoBehaviour {
	
	private int currentWave;
	private float waveMultiplier;

	private float waveClock = 0f;
	private float windTime = 30f;
	private float buildTime = 45f;
	
	public GUIText output;

	public wind windObj;
	public debris debrisObj;
	//public List<debris> debrisList = new List<debris>();
	
	private bool waveOn;
	
	// Use this for initialization
	void Start () 
	{
		//kill debris
		waveOn = false;
		currentWave = 1;
		waveMultiplier = 1.02f;

		waveClock = buildTime;
		//windObj.beginWave(100f);
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	// Once per physics check
	void FixedUpdate ()
	{
		waveClock -= Time.deltaTime;

		if (!waveOn) 							//if not currently in a wave / in build phase
		{
			output.text = "next wave in: " + (int)waveClock;
			//float waveChance = Random.Range (0, 10000);
			//if (waveChance <= 10) 
			if (waveClock <= 0)					//when build phase over, start wave
			{ 			
				removeDebris();								
				waveOn = true;
				windObj.beginWave(windObj.getMaxWSpeed () * waveMultiplier);
				waveClock = windTime;
			}
		}
		
		if (waveOn) 
		{
			output.text = "remaining time: " + (int)waveClock;
			float throwChance = Random.Range (0, 10000);
			if (throwChance <= 200) 
			{ 																			
				//debrisList.Add(new debris());							//create debris
				//debris d = debrisList[debrisList.Count-1];			//throw newly added item
				
				//Vector3 windDir = windObj.getWindDir();
				int angle = windObj.getAngle();
				debrisObj.throwDebris(angle);
			}
			
			//if (windObj.getWindState() == 0)
			if (waveClock <= 0)
			{
				currentWave +=1;
				//waveMultiplier += 0.05f;
				waveOn = false;
				windObj.setWindStateDown();
				waveClock = buildTime;

			}			
		}		
	}

	void removeDebris()
	{
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Debris")) 
		{
			//Destroy(obj);
		}
	}

	//get remainingTime for score
}
