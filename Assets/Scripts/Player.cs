﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private int blockCount;
	public GUIText text;

	// Use this for initialization
	void Start () {
		this.blockCount =20;
	}
	
	// Update is called once per frame
	void Update () {
		this.drawText();
	}
	
	public void addBlock() {
		this.blockCount +=12;
		this.drawText();
	}
	
	public void removeBlock() {
		this.blockCount--;
		this.drawText();
	}
	
	public int getBlockCount() {
		return this.blockCount;
	}
	
	private void drawText() {
		this.text.text ="BLOCKS - " +this.blockCount;
	}
}
