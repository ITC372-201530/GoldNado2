using UnityEngine;
using System.Collections;

public class blockCounterScript : MonoBehaviour {
	
	public Texture2D blocksTexture;
	public Texture2D zeroTexture;
	public Texture2D oneTexture;
	public Texture2D twoTexture;
	public Texture2D threeTexture;
	public Texture2D fourTexture;
	public Texture2D fiveTexture;
	public Texture2D sixTexture;
	public Texture2D sevenTexture;
	public Texture2D eightTexture;
	public Texture2D nineTexture;
	public Texture2D tenTexture;
	public Texture2D elevenTexture;
	public Texture2D twelveTexture;
	public Texture2D thirteenTexture;
	public Texture2D fourteenTexture;
	public Texture2D fifteenTexture;
	public Texture2D sixteenTexture;
	public Texture2D seventeenTexture;
	public Texture2D eighteenTexture;
	public Texture2D nineteenTexture;
	public Texture2D twentyTexture;
	public Texture2D defaultTexture;
	
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		
	}
	
	void OnGUI()
	{
		float xMin = (Screen.width) - (blocksTexture.width * 2);
		float yMin = (Screen.height) - (blocksTexture.height * 2);
		GUI.DrawTexture (new Rect (xMin, yMin, blocksTexture.width, blocksTexture.height), blocksTexture);
		
		switch (gameVariables.ammunition) {
		case 0:
			drawAmmoCount(zeroTexture);
			break;
		case 1:
			drawAmmoCount(oneTexture);
			break;
		case 2:
			drawAmmoCount(twoTexture);
			break;
		case 3:
			drawAmmoCount(threeTexture);
			break;
		case 4:
			drawAmmoCount(fourTexture);
			break;
		case 5:
			drawAmmoCount(fiveTexture);
			break;
		case 6:
			drawAmmoCount(sixTexture);
			break;
		case 7:
			drawAmmoCount(sevenTexture);
			break;
		case 8:
			drawAmmoCount(eightTexture);
			break;
		case 9:
			drawAmmoCount(nineTexture);
			break;
		case 10:
			drawAmmoCount(tenTexture);
			break;
		case 11:
			drawAmmoCount(elevenTexture);
			break;
		case 12:
			drawAmmoCount(twelveTexture);
			break;
		case 13:
			drawAmmoCount(thirteenTexture);
			break;
		case 14:
			drawAmmoCount(fourteenTexture);
			break;
		case 15:
			drawAmmoCount(fifteenTexture);
			break;
		case 16:
			drawAmmoCount(sixteenTexture);
			break;
		case 17:
			drawAmmoCount(seventeenTexture);
			break;
		case 18:
			drawAmmoCount(eighteenTexture);
			break;
		case 19:
			drawAmmoCount(nineteenTexture);
			break;
		case 20:
			drawAmmoCount(twentyTexture);
			break;
		default:
			drawAmmoCount(defaultTexture);
			break;
		}
		
		
		
	}
	
	void drawAmmoCount(Texture2D numberTexture)
	{
		float xMin = (Screen.width) - (numberTexture.width * 3.6f);
		float yMin = (Screen.height) - (numberTexture.height * 2);
		GUI.DrawTexture (new Rect (xMin, yMin, numberTexture.width, numberTexture.height), numberTexture);
	}
	
	
}
