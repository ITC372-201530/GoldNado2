using UnityEngine;
using System.Collections;

public class PlaceBlock : MonoBehaviour {
	public GameObject goldBrick;
	public GameObject Building;
	public GameObject camera;
	public GameObject shadow;
	
	public float initBlockDist =5.0f;
	
	private GameObject tmpBlock;
	private GameObject tmpShadow;
	
	private float lockPos =0;
	private float blockDist;
	
	private Player player;
	
	
	// Use this for initialization
	void Start () {
		GameObject go =GameObject.FindGameObjectWithTag("gameControls") as GameObject;
		
		this.blockDist =this.initBlockDist;
		this.player =(Player)go.GetComponent("Player");
	}
	
	// Update is called once per frame
	void Update () {
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
		
		if(Input.GetKey(KeyCode.C)) {
			if(this.tmpBlock !=null) {
				Quaternion rot =this.tmpBlock.transform.rotation;
				rot.y -=0.01f;
				this.tmpBlock.transform.rotation =rot;
			}
		}
		
		if(Input.GetKey(KeyCode.V)) {
			if(this.tmpBlock !=null) {
				Quaternion rot =this.tmpBlock.transform.rotation;
				rot.y +=0.01f;
				this.tmpBlock.transform.rotation =rot;
			}
		}
		
		if(Input.GetAxis("Mouse ScrollWheel") !=0) {
			if(this.tmpBlock !=null) {
				Vector3 pos =this.camera.transform.position;
				Vector3 dir =this.camera.transform.forward;
				this.blockDist -=-Input.GetAxis("Mouse ScrollWheel");
				
				Vector3 spawnPos =pos +dir *this.blockDist;
				this.tmpBlock.transform.position =spawnPos;
			}
		}
		
		if(Input.GetAxis("Mouse Y") !=0) {
			if(this.tmpBlock !=null) {
				Vector3 upP =this.tmpBlock.transform.position;
				upP.y +=Input.GetAxis("Mouse Y");
				this.tmpBlock.transform.position =upP;
			}
		}
		
	}
	
	void showBlock() {
		Vector3 pos =this.camera.transform.position;
		Vector3 dir =this.camera.transform.forward;
		Quaternion rot =this.camera.transform.rotation;
		rot.x =0;
		
		Vector3 spawnPos =pos +dir *this.blockDist;
		
		this.tmpBlock =Instantiate(this.goldBrick, spawnPos, rot) as GameObject;
		this.tmpShadow =Instantiate(this.shadow, spawnPos, this.shadow.transform.rotation) as GameObject;
		this.tmpShadow.transform.parent =this.tmpBlock.transform;
		
		this.tmpBlock.AddComponent("PlaceBlockDetection");
		PlaceBlockDetection spt =(PlaceBlockDetection)this.tmpBlock.GetComponent("PlaceBlockDetection");
		spt.detectionColor =new Color(0.5f, 0, 0, 0.5f);
		this.tmpBlock.transform.parent =this.transform;
		
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
			
			this.tmpBlock =null;
			this.player.removeBlock();
		}
		
		this.blockDist =this.initBlockDist;
	}
	
}
