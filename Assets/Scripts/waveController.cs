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
	private bool gameOver = false;
	private bool testMode = false;
	
	private const float windTime	= 15f;//15
	private const float buildTime 	= 45f;//45
	private const float heightTime 	= 2f;
	
	public GUIText output;
	
	public GUIText heightText;
	public GUIText scoreText;
	public GUIText waveText;
	public GUIText waveStartText;
	
	public wind windObj;
	public debris debrisObj;
	
	public GameObject debrisHolder;
	
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
		tempHeight = 0;
		heightClock = 2;
		heightFlag = false;

		//testMode = true;
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
			heightClock += Time.deltaTime;
		} 
		if (!heightFlag)
		{
			heightClock = 0;
		}
		int cHeight = (int)((currentHeight / 0.75f) + 0.5);
		
		if (!waveOn) 							//if not currently in a wave / in build phase
		{
			//output.text = "Next Wave In: " + (int)waveClock;
			this.waveStartText.text ="WAVE STARTS IN " + (int)waveClock;
			
			if (waveClock <= 0 && !gameOver)					//when build phase over, start wave
			{ 			
				removeDebris();	
				debrisThrown = 0;
				currentWave += 1;
				goalHeight = (int)((currentWave * 2) * waveMultiplier);
				waveOn = true;
				windObj.beginWave(windObj.getMaxWSpeed() * waveMultiplier);
				waveClock = windTime;
			}
		}
		
		if (waveOn) 							//whilst in wave
		{
			//output.text = "Remaining Time: " + (int)waveClock;
			this.waveStartText.text ="WAVE ENDS IN " + (int)waveClock;
			float throwChance = Random.Range (0, 10000);
			if (throwChance <= 200 * waveMultiplier) 
			{ 																
				int angle = windObj.getAngle();
				debrisObj.throwDebris(angle);
				debrisThrown +=1;
			}
			//check if reached goal height
			if (cHeight >= goalHeight)
			{
				endWave ();
			}

			if (waveClock <= 0)
			{
				endWave();
				if (!testMode)
				{
					gameOver = true;
				}
				//out of time before reaching goal height = gameOver
			}			
		}
		checkGoalHeight();
		//output.text += " Wave: " + currentWave + "  Goal Height: " + goalHeight + "  SCORE:  " + score + "  CurrentHeight: " + cHeight;
		this.heightText.text ="HEIGHT - " +cHeight +" - " +goalHeight;
		this.scoreText.text ="SCORE - " +score;
		this.waveText.text ="WAVE - " +currentWave;
		
		if (gameOver)
		{
			PlayerPrefs.SetInt("score", score);
			PlayerPrefs.SetInt("wave", currentWave);
			Application.LoadLevel("endScene");
		}
	}
	
	void checkGoalHeight()
	{
		//tempHeight = 0;
		//float maxHeight = 0;
		float yPos = 0;
		float tHold = 0.002f; //threshold
		float maxY = 0;
		//float tempHeight = 0;
		
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Gold")) 
		{
			if (obj.constantForce != null)
			{
				yPos = obj.transform.position.y;
				if (yPos >= maxY-tHold)		
				{
					maxY = yPos;					//find highest Y of all blocks
				}
			}
		}
		
		if (maxY >= currentHeight)					//if maxY is higher than tempHeight
		{
			tempHeight = maxY;						//store maxY in tempHeight
			heightFlag = true;						//begin timer
		}
		
		if (maxY <= currentHeight)					//if maxY falls below temp height
		{
			currentHeight = maxY;					//lower currentHeight
			heightFlag = false;						//reset timer
			heightClock = 0;
			tempHeight = 0;
		}
		
		if (heightClock >= heightTime)				//if reach time without resetng timer (block hasn't fallen)
		{
			currentHeight = tempHeight;				//save tempHeight as current height.
			heightFlag = false;
			heightClock = 0;
			tempHeight = 0;
		}
		
		
		
		//output.text += "  temp: " + tempHeight + "  maxY: " + maxY + "  currentHeight:  " + currentHeight +  "  clock: " + heightClock;
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
		float tScore = waveClock * 100; 							//add remaining time to score (seconds * 100)
		tScore += currentWave * 200;								//for completeing wave
		tScore += currentHeight * 50;							//height 
		tScore = tScore * waveMultiplier;						//multiply by difficulty
		
		
		score += (int)tScore;
		waveMultiplier += 0.02f;
		waveOn = false;
		windObj.setWindStateDown();
		waveClock = buildTime;
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Debris")) {
			if(obj.transform.parent ==null) {
				Destroy(obj);
			}
		}
		
	}
	
	//get remainingTime for score
}
