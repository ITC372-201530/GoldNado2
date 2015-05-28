using UnityEngine;
using System.Collections;

public class ammoObjectScript : MonoBehaviour {


	public float spinSpeed = 10.0f;
	public AudioClip ammoPickup;
	private AudioSource source;

	// Use this for initialization
	void Start () {
	
	}

	void Awake(){
		
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate (Vector3.left, spinSpeed * Time.deltaTime);
	
	}

	void OnTriggerEnter(Collider collider){
		source.Play();
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
