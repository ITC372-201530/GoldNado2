using UnityEngine;
using System.Collections;

public class PickupGold : MonoBehaviour {
	private spawnBlocks sb;
	private Player player;
	private PlaceBlock placeBlock;

	// Use this for initialization
	void Start () {
		GameObject go =GameObject.FindGameObjectWithTag("gameControls") as GameObject;
		//PlaceBlockDetection spt =(PlaceBlockDetection)this.tmpBlock.GetComponent("PlaceBlockDetection");
		this.sb =(spawnBlocks)go.GetComponent("spawnBlocks");
		this.player =(Player)go.GetComponent("Player");
		
		go =GameObject.FindGameObjectWithTag("Player") as GameObject;
		this.placeBlock =(PlaceBlock)go.GetComponent("PlaceBlock");
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag =="Player") {
			this.player.addBlock();
			this.sb.removeSpawnCount();
			this.placeBlock.playPickupGold();
			Destroy(this.gameObject);
		}
	}
}
