using UnityEngine;
using System.Collections;

public class ammoCounterScript : MonoBehaviour {

	public GUIText text;

	public Texture2D ammoTexture;
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
	public Texture2D defaultTexture;
	
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI()
	{
		this.drawText();
	/*
		float xMin = (Screen.width / 12) - (ammoTexture.width / 12);
		float yMin = (Screen.height) - (ammoTexture.height * 2);
		GUI.DrawTexture (new Rect (xMin, yMin, ammoTexture.width, ammoTexture.height), ammoTexture);

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
		default:
			drawAmmoCount(defaultTexture);
			break;
		}
		*/
	}
	
	private void drawText() {
		this.text.text ="AMMO - " +gameVariables.ammunition;
	}

	void drawAmmoCount(Texture2D numberTexture)
	{
		float xMin = (Screen.width / 12) + (numberTexture.width * 4);
		float yMin = (Screen.height) - (numberTexture.height * 2);
		GUI.DrawTexture (new Rect (xMin, yMin, numberTexture.width, numberTexture.height), numberTexture);
	}


}
