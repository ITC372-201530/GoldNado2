using UnityEngine;
using System.Collections;

public class windDir : MonoBehaviour {
	//For holding the compass textures
	public Texture2D bg;
	public Texture2D windBubble;
	public Texture2D bubble;
	
	
	//"North" in the game
	//0 for + Z Axis, 90 for + X Axis, etc
	public float north;
	
	//Where the compass bubble needs to be inside10 the compass
	public float radius;
	
	//Where the compass needs to be placed
	public Vector2 center;
	
	//Size in pixels about how big the compass should be
	public Vector2 compassSize;
	public Vector2 bubbleSize;
	
	public GameObject windController;
	
	float rot, rotW, x, y, xW, yW;
	
	
	
	// Use this for initialization
	void Start()
	{
		//Set the placement of compass from size and center
		compassRect = new Rect(
			1100, 20,
			compassSize.x,
			compassSize.y);
		
	}
	
	Rect compassRect;
	void OnGUI()
	{
		
		//GUI.DrawTexture(new Rect(100, 30, 100, 100), this.bg);
		
		// Draw background
		GUI.DrawTexture(compassRect, bg);
		
		// Draw bubble
		GUI.DrawTexture(new Rect(1100 +center.x + x - bubbleSize.x / 2, 20 +center.y + y - bubbleSize.y/2, bubbleSize.x, bubbleSize.y), bubble);
		GUI.DrawTexture(new Rect(1100 +center.x + xW - bubbleSize.x / 2, 20 +center.y + yW - bubbleSize.y/2, bubbleSize.x, bubbleSize.y), windBubble);
	}
	
	void Update()
	{
	
		wind w =this.windController.GetComponent<wind>();
	
		// Note -90 compensation cos north is along 2D Y axis
		rot = (-90 + this.transform.eulerAngles.y - north)* Mathf.Deg2Rad;
		rotW = (-90 +w.getAngle() - north)* Mathf.Deg2Rad;
		
		// Bubble position
		x = radius * Mathf.Cos(rot);
		y = radius * Mathf.Sin(rot);
		
		xW = radius * Mathf.Cos(rotW);
		yW = radius * Mathf.Sin(rotW);
		
		
	}
}
