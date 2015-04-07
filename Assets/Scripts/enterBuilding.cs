using UnityEngine;
using System.Collections;

public class enterBuilding : MonoBehaviour {
	public GameObject outside;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag =="Player") {
			if(this.outside !=null) //outside seems to go to null as soon as we walk inside the block :/
				this.outside.collider.isTrigger =true;
		}
	}
	
	void OnTriggerExit(Collider other) {
		if(other.gameObject.tag =="Player") {
			if(this.outside !=null) //outside seems to go to null as soon as we walk inside the block :/
				this.outside.collider.isTrigger =false;
		}
	}
}
