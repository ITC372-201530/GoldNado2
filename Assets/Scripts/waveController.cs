using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class waveController : MonoBehaviour {
	
	private int currentWave;
	private int score;
	private int goalHeight;
	private int debrisThrown;
	private float waveMultiplier;
	private float waveClock;

	private float currentHeight;
	private float tempHeight;
	private float heightClock;
	private bool heightFlag;

	private const float windTime = 10f;
	private const float buildTime = 15f;
	
	public GUIText output;


	public wind windObj;
	public debris debrisObj;
	//public List<debris> debrisList = new List<debris>();
	
	private bool waveOn;
	
	// Use this for initialization
	void Start () 
	{
		waveOn = false;
		currentWave = 0;
		score = 0;
		goalHeight = 0;
		debrisThrown = 0;
		waveMultiplier = 1f;
		waveClock = buildTime;		
		currentHeight = 0;
		heightClock = 2;
		heightFlag = false;
	}
	
	// Update is called once per frame
	void Update () 
	{		
	}
	
	// Once per physics check
	void FixedUpdate ()
	{
		waveClock -= Time.deltaTime;

		if (heightFlag) 
		{
			heightClock -= Time.deltaTime;
		} 
		else 
		{
			heightClock = 2;
		}

		if (!waveOn) 							//if not currently in a wave / in build phase
		{
			output.text = "Next Wave In: " + (int)waveClock;

			if (waveClock <= 0)					//when build phase over, start wave
			{ 			
				removeDebris();	
				debrisThrown = 0;
				currentWave += 1;
				goalHeight = (int)((currentWave * 3) * waveMultiplier);
				waveOn = true;
				windObj.beginWave(windObj.getMaxWSpeed() * waveMultiplier);
				waveClock = windTime;
			}
		}
		
		if (waveOn) 							//whilst in wave
		{
			output.text = "Remaining Time: " + (int)waveClock;
			float throwChance = Random.Range (0, 10000);
			if (throwChance <= 200 * waveMultiplier) 
			{ 																
				int angle = windObj.getAngle();
				debrisObj.throwDebris(angle);
				debrisThrown +=1;
			}
			//check if reached goal height

			if (waveClock <= 0)
			{
				endWave();
				//out of time before reaching goal height = gameOver
			}			
		}
		checkGoalHeight();
		output.text += " Wave: " + currentWave + "  Goal Height: " + goalHeight + "  SCORE:  " + score + "   T: " + debrisThrown;
	}

	void checkGoalHeight()
	{
		//tempHeight = 0;
		//float maxHeight = 0;
		float yPos = 0;

		foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Gold")) 
		{
			if (obj.constantForce != null)
			{
				yPos = obj.transform.position.y;
				if (yPos >= tempHeight-0.02)
				{
					tempHeight = yPos;
					//maxHeight = tempHeight;
					heightClock = 2;
					heightFlag = true;
				}

				if (heightClock == 0)	//if been at this height for 2 seconds
				{
					//currentHeight = tempHeight;
					//heightFlag = false;
				}
			}
		}
		//output.text += "  temp: " + tempHeight + "  yPos: " + yPos + "  currentHeight:  " + currentHeight +  "  clock: " + heightClock;
	}

	void removeDebris()
	{
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Debris")) 
		{
			//Destroy(obj);
		}
	}

	void endWave()
	{
		float tScore = (waveClock * 10)*(waveMultiplier) + currentWave * 10; //add remaining time to score (seconds * 10)
		score = (int)tScore;
		waveMultiplier += 0.02f;
		waveOn = false;
		windObj.setWindStateDown();
		waveClock = buildTime;
	}

	//get remainingTime for score
}
