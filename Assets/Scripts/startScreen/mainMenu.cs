using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour {	
	public Text hScore;
	// Use this for initialization
	void Start () {
		int score = PlayerPrefs.GetInt("hScore");
		this.hScore.text +=score;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OnClickPlay(){
		Application.LoadLevel("goldNado");
	}
	
	public void OnClickExit(){
		Application.Quit();
	}
}
