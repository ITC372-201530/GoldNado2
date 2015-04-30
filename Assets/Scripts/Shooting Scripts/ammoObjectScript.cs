using UnityEngine;
using System.Collections;

public class ammoObjectScript : MonoBehaviour {


	public float spinSpeed = 10.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate (Vector3.back, spinSpeed * Time.deltaTime);
	
	}

	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.tag == "Player" && gameVariables.ammunition < 9) {
			gameVariables.ammunition += 2;
			this.gameObject.SetActive (false);
			gameVariables.currentPickups--;
			print ("Current Pickups:" + gameVariables.currentPickups);
		} else if (collider.gameObject.tag == "Player" && gameVariables.ammunition == 9) {
			gameVariables.ammunition += 1;
			this.gameObject.SetActive (false);
			gameVariables.currentPickups--;
			print ("Current Pickups:" + gameVariables.currentPickups);
		}
	}
}
