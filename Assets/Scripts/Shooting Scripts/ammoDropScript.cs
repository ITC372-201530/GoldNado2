using UnityEngine;
using System.Collections;

public class ammoDropScript : MonoBehaviour {

	public GameObject ammo1;
	public GameObject ammo2;
	public GameObject ammo3;
	public GameObject ammo4;

	public int maxAmmoPickups = 2;


	private bool ammo1isOn;
	private bool ammo2isOn;
	private bool ammo3isOn;
	private bool ammo4isOn;

	// Use this for initialization
	void Start () {

		ammo1isOn = false;
		ammo2isOn = false;
		ammo3isOn = false;
		ammo4isOn = false;

		gameVariables.currentPickups = 0;

		ammo1.SetActive (false);
		ammo2.SetActive (false);
		ammo3.SetActive (false);
		ammo4.SetActive (false);


	
	}
	
	// Update is called once per frame
	void Update () {

		if (gameVariables.currentPickups < maxAmmoPickups) {


			int picker = Random.Range(1,5);

			switch(picker){
			case 1:
				if(!ammo1isOn){
					ammo1isOn = true;
					ammo1.SetActive(true);
					gameVariables.currentPickups++;
				}
				break;
			case 2:
				if(!ammo2isOn){
					ammo2isOn = true;
					ammo2.SetActive(true);
					gameVariables.currentPickups++;
				}
				break;
			case 3:
				if(!ammo3isOn){
					ammo3isOn = true;
					ammo3.SetActive(true);
					gameVariables.currentPickups++;
				}
				break;
			case 4:
				if(!ammo4isOn){
					ammo4isOn = true;
					ammo4.SetActive(true);
					gameVariables.currentPickups++;
				}
				break;
			default:
				break;
			}

		}



	
	}
}
