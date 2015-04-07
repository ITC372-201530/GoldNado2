using UnityEngine;
using System.Collections;

public class PlaceBlockDetection : MonoBehaviour {
	public Color col;
	private int triggerCount; //We need to keep track of how many items we have hit, this is so we dont lose the red when we move out of one gameObject but are still inside another
	
	public Color detectionColor;
	public bool hasLight;
	
	// Use this for initialization
	void Start () {
		this.col =this.renderer.material.color;
		this.triggerCount =0;
		this.hasLight =true;
	}
	
	// Update is called once per frame
	void Update () {
			
	}
	
	void OnCollisionEnter(Collision col) {
		if(this.hasLight) {
			foreach (Transform childTransform in this.transform) {
				Destroy(childTransform.gameObject);
			}
			this.hasLight =false;
		}
	}
	
	void OnTriggerEnter(Collider other) {
		this.renderer.material.color =this.detectionColor;
		this.triggerCount++;
	}
	
	void OnTriggerExit(Collider other) {
		this.triggerCount--;
		if(this.triggerCount ==0)
			this.renderer.material.color =this.col;
	}
	
	public bool IsInideObject() {
		if(this.triggerCount >0)
			return true;
		return false;
	}
}
