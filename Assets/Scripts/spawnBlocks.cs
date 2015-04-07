using UnityEngine;
using System.Collections;

public class spawnBlocks : MonoBehaviour {
	public GameObject spawnBlock;
	
	private int spawnCount;
	private bool spawnning =false;
	// Use this for initialization
	void Start () {
		this.spawnCount =0;
		this.spawn();
		
		while(!this.spawn());
		while(!this.spawn());
	}
	
	// Update is called once per frame
	void Update () {
		if(!this.spawnning) {
			if(this.spawnCount <2) {
				this.spawnning =true;
				InvokeRepeating("spawn", Random.Range(5f, 10f), 0f);
			}
		}
	}
	
	public void removeSpawnCount() {
		this.spawnCount--;
	}
	
	private bool spawn() {
		int i =0;
		int spawnPos =Random.Range(0, 3);
		bool res =true;
		
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("spawnBlock")) {
			if(i ==spawnPos) {
				if(obj.transform.childCount ==0) {
					Vector3 pos =obj.transform.position;				
					GameObject tmp =Instantiate(this.spawnBlock, pos,  Quaternion.identity) as GameObject;				
					tmp.transform.parent =obj.gameObject.transform;
				
					this.spawnCount++;
					break;
				} else {
					res =false;
					break;
				}
			}
			i++;
		}
		
		this.spawnning =false;
		return res;
	}
}
