using UnityEngine;
using System.Collections;

public class PickupGold : MonoBehaviour {
	private spawnBlocks sb;
	private Player player;

	// Use this for initialization
	void Start () {
		GameObject go =GameObject.FindGameObjectWithTag("gameControls") as GameObject;
		//PlaceBlockDetection spt =(PlaceBlockDetection)this.tmpBlock.GetComponent("PlaceBlockDetection");
		this.sb =(spawnBlocks)go.GetComponent("spawnBlocks");
		this.player =(Player)go.GetComponent("Player");
		
		print (this.sb);
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnTriggerEnter(Collider other) {
		this.player.addBlock();
		this.sb.removeSpawnCount();
		
		Destroy(this.gameObject);
	}
}
