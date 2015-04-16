using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class waveController : MonoBehaviour {

	private int currentWave;
	private float waveMultiplier;

	public wind windObj;
	public debris debrisObj;
	public List<debris> debrisList = new List<debris>();

	private bool waveOn;

	// Use this for initialization
	void Start () 
	{
		//kill debris
		waveOn = false;
		currentWave = 1;
		waveMultiplier = 1.1f;
		//windObj.beginWave(100f);
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	// Once per physics check
	void FixedUpdate ()
	{

		if (!waveOn) 
		{
			float waveChance = Random.Range (0, 10000);
			if (waveChance <= 25) { 											//small chance a wave will start
				waveOn = true;
				windObj.beginWave(windObj.getMaxWSpeed () * waveMultiplier);
			}
		}

		if (waveOn) 
		{
			float throwChance = Random.Range (0, 10000);
			if (throwChance <= 200) { 																			
				//debrisList.Add(new debris());							//create debris
				//debris d = debrisList[debrisList.Count-1];			//throw newly added item

				//Vector3 windDir = windObj.getWindDir();
				int angle = windObj.getAngle();
				debrisObj.throwDebris(angle);
			}

			if (windObj.getWindState() == 0)
			{
				currentWave +=1;
				//waveMultiplier += 0.05f;
				waveOn = false;
			}

		}






	}
}
