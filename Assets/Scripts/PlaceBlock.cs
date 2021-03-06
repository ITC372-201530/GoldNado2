﻿using UnityEngine;
using System.Collections;

public class PlaceBlock : MonoBehaviour {
	public GameObject goldBrick;
	public GameObject Building;
	public GameObject camera;
	public GameObject shadow;
	
	public AudioClip dropGold;
	public AudioClip pickupGold;
	
	public GameObject audioSource;
	
	public float initBlockDist =5.0f;
	
	private GameObject tmpBlock;
	private GameObject tmpShadow;
	
	private float lockPos =0;
	private float blockDist;
	
	private Player player;
	
	private bool buildMode;
	
	
	// Use this for initialization
	void Start () {
		GameObject go =GameObject.FindGameObjectWithTag("gameControls") as GameObject;
		
		this.blockDist =this.initBlockDist;
		this.player =(Player)go.GetComponent("Player");
		
		this.buildMode =false;
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if(Input.GetKeyDown(KeyCode.B)) {
			if(this.player.getBlockCount() >0) {
				this.showBlock();
			}
		}
		
		if(Input.GetKeyUp(KeyCode.B)) {
			if(this.player.getBlockCount() >0) {
				this.placeBlock();
			}
		}
		*/
		
		//During testing i noticed that my finger keept naturally moving to the F key to build
		if(Input.GetKeyDown(KeyCode.F)) {
			if(this.player.getBlockCount() >0) {
				if(this.buildMode ==false) {
					this.buildMode =true;
					this.showBlock();
				} else {
					this.buildMode =false;
					this.placeBlock();
				}
			}
		}
		
		if(Input.GetKey(KeyCode.E)) {
			if(this.tmpBlock !=null) {
				this.tmpBlock.transform.Rotate(Vector3.up, -(50 *Time.deltaTime));
			}
		}
		
		if(Input.GetKey(KeyCode.Q)) {
			if(this.tmpBlock !=null) {
				this.tmpBlock.transform.Rotate(Vector3.up, 50 *Time.deltaTime);
			}
		}
		
		if(Input.GetAxis("Mouse ScrollWheel") !=0) {
			if(this.tmpBlock !=null) {
				//Vector3 pos =this.camera.transform.position;
				Vector3 pos =this.tmpBlock.transform.position;
				Vector3 dir =this.camera.transform.forward;
				Vector3 spawnPos;
				if(Input.GetAxis("Mouse ScrollWheel") >0)
					spawnPos =pos +dir *(5.5f *Time.deltaTime);
				else
					spawnPos =pos +dir *-(5.5f *Time.deltaTime);
					
				this.tmpBlock.transform.position =spawnPos;
			}
		}
		
		if(Input.GetAxis("Mouse Y") !=0) {
			if(this.tmpBlock !=null) {
				Quaternion r =this.tmpBlock.transform.rotation;
				r.x =0;
				r.z =0;
				this.tmpBlock.transform.rotation =r;
				//Vector3 upP =this.tmpBlock.transform.position;
				//upP.y +=Input.GetAxis("Mouse Y");
				//this.tmpBlock.transform.position =upP;
			}
		}
		
	}
	
	void showBlock() {
		Vector3 pos =this.camera.transform.position;
		Vector3 dir =this.camera.transform.forward;
		Quaternion rot =this.camera.transform.rotation;
		rot.y =90;
		
		Vector3 spawnPos =pos +dir *this.blockDist;
		
		this.tmpBlock =Instantiate(this.goldBrick, spawnPos, rot) as GameObject;
		this.tmpBlock.tag ="buildBlock";
		
		this.tmpShadow =Instantiate(this.shadow, spawnPos, this.shadow.transform.rotation) as GameObject;
		this.tmpShadow.transform.parent =this.tmpBlock.transform;
		
		this.tmpBlock.AddComponent("PlaceBlockDetection");
		PlaceBlockDetection spt =(PlaceBlockDetection)this.tmpBlock.GetComponent("PlaceBlockDetection");
		spt.detectionColor =new Color(0.5f, 0, 0, 0.5f);
		this.tmpBlock.transform.parent =this.camera.transform;//this.transform;
		
		this.tmpBlock.transform.rotation =Quaternion.Euler(this.lockPos, this.tmpBlock.transform.rotation.eulerAngles.y, this.lockPos); //In order to stop the block from rotating around to the camera rotation we need to reset the rotation back after we init the block
		Color col =this.tmpBlock.renderer.material.color;
		col.a =0.5f;
		this.tmpBlock.renderer.material.color =col;
	}
	
	void placeBlock() {
		//Before we can place a block we need to make sure it isnt inside another object
		PlaceBlockDetection spt =(PlaceBlockDetection)this.tmpBlock.GetComponent("PlaceBlockDetection");
		if(this.tmpBlock.transform.position.y <0 || spt.IsInideObject() ==true) { //Destroy the block
			Vector3 tmpPos =this.tmpBlock.transform.position;
			tmpPos.y =-1000;
			this.tmpBlock.transform.position =tmpPos;
			
			Destroy(this.tmpBlock, 0.1f);
			tmpBlock =null;
		} else {
			this.tmpBlock.transform.parent =this.Building.transform;
			this.tmpBlock.collider.isTrigger =false; //Because we have place the block onto the game scene we no longer want it to just be a trigger
			this.tmpBlock.collider.attachedRigidbody.useGravity =true; //Allow gravity to affect the block
			Color col =this.tmpBlock.renderer.material.color;
			col.a =1;
			this.tmpBlock.renderer.material.color =col;
			
			spt.detectionColor =new Color(0.5f, 0.5f, 0);
			spt.col =col;
			 	
			this.tmpBlock.constantForce.enabled =true;
			this.tmpBlock.tag ="Gold";
			
			this.tmpBlock =null;
			this.player.removeBlock();
			
			AudioSource source =this.audioSource.GetComponent<AudioSource> ();
			
			source.PlayOneShot(this.dropGold, 1f);
		}
		
		this.blockDist =this.initBlockDist;
	}
	
	public void playPickupGold() {
		
	
		AudioSource source =this.audioSource.GetComponent<AudioSource> ();
		source.PlayOneShot(this.pickupGold, 1f);
	}
	
}
