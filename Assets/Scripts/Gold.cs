using UnityEngine;
using System.Collections;

public class Gold : MonoBehaviour {
	public GameObject dBrick;
	
	private float blockHealth;
	
	// Use this for initialization
	void Start () {
		this.blockHealth =20.0f;
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnCollisionEnter(Collision col){
		if(col.relativeVelocity.magnitude >5) {
			this.renderer.material.color =new Color(
				this.renderer.material.color.r +col.relativeVelocity.magnitude,
				this.renderer.material.color.g,
				this.renderer.material.color.b
			);
			this.blockHealth -=col.relativeVelocity.magnitude;
			if(this.blockHealth <=0) {
				
				InvokeRepeating("InitBlock", 0.1f, 0f);
			}
		}
			
			//Debug.Log(col.relativeVelocity.magnitude);
			
	}
	
	void InitBlock() {
		Vector3 pos =gameObject.transform.position;
		Quaternion rot =gameObject.transform.rotation;
		//Destroy(this.gameObject);
		Instantiate(dBrick, pos, rot);
	}
}
