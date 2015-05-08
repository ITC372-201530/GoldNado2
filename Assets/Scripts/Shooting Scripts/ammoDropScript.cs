using UnityEngine;
using System.Collections;

public class ammoDropScript : MonoBehaviour {
	
	public GameObject ammo1;
	public GameObject ammo2;
	public GameObject ammo3;
	public GameObject ammo4;
	
	private bool ammo1isActive;
	private bool ammo2isActive;
	private bool ammo3isActive;
	private bool ammo4isActive;
	
	public int maxAmmoPickups = 2;
	
	// Use this for initialization
	void Start () {
		
		
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
				if(!ammo1.activeSelf){
					ammo1.SetActive(true);
					gameVariables.currentPickups++;
				}
				break;
			case 2:
				if(!ammo2.activeSelf){
					ammo2.SetActive(true);
					gameVariables.currentPickups++;
				}
				break;
			case 3:
				if(!ammo3.activeSelf){
					ammo3.SetActive(true);
					gameVariables.currentPickups++;
				}
				break;
			case 4:
				if(!ammo4.activeSelf){
					ammo4.SetActive(true);
					gameVariables.currentPickups++;
				}
				break;
			default:
				break;
			}
			
		}
		
		
		
		
	}
	
	
	void ammoActivator (){
		
		
		
	}
}
