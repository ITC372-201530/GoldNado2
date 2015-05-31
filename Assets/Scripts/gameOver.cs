using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameOver : MonoBehaviour {
	public Text score;
	public Text hScore;
	public Text wave;
	
	// Use this for initialization
	void Start () {
		Screen.showCursor =true;
	
		int score = PlayerPrefs.GetInt("score");
		int wave = PlayerPrefs.GetInt("wave");
		int hScore = PlayerPrefs.GetInt("hScore");
		
		this.score.text ="SCORE - " +score;
		this.wave.text ="WAVE - " +wave;		
				
		if(hScore >score) {
			PlayerPrefs.SetInt("hScore", score);
			this.hScore.text ="NEW HIGH SCORE";
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
