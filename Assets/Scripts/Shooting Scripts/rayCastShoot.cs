using UnityEngine;
using System.Collections;

public class rayCastShoot : MonoBehaviour {
	
	
	public float damage = 100.0f;
	public float hitRange = 100.0f;
	public float spreadFactor = 0.02f;
	
	public GameObject gun1;
	public GameObject gun2;
	public GameObject gun3;
	public GameObject gun4;
	private GameObject currentGun;
	
	
	public Transform yellowEffect;
	public Transform redEffect;
	public Transform blueEffect;
	public Transform greenEffect;
	private Transform placeHolderEffect;
	
	//public GameObject[] weapons;
	//public GameObject currentWeapon;
	
	int weaponNumber = 1;
	
	// Use this for initialization
	void Start () {
		
		gameVariables.ammunition = 10;
		currentGun = gun1;
		gunEnabler (currentGun);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2,0));
		
		Vector3 direction = transform.forward;
		direction.x += Random.Range (-spreadFactor, spreadFactor);
		direction.y += Random.Range (-spreadFactor, spreadFactor);
		direction.z += Random.Range (-spreadFactor, spreadFactor);
		
		switch(weaponNumber){
			
		case 1:
			currentGun = gun1;
			gunEnabler(currentGun);
			placeHolderEffect = yellowEffect;
			break;
		case 2:
			currentGun = gun2;
			gunEnabler(currentGun);
			placeHolderEffect = redEffect;
			break;
		case 3:
			currentGun = gun3;
			gunEnabler(currentGun);
			placeHolderEffect = blueEffect;
			break;
		case 4:
			currentGun = gun4;
			gunEnabler(currentGun);
			placeHolderEffect = greenEffect;
			break;
		default:
			currentGun = gun1;
			gunEnabler(currentGun);
			placeHolderEffect = yellowEffect;
			break;
			
		}
		
		
		if(Input.GetButtonDown("Fire1") && gameVariables.ammunition > 0){
			
			gameVariables.ammunition--;
			
			print("Weapon Number:"+weaponNumber);
			print("Ammunition:"+gameVariables.ammunition);
			
			//Where the switch went
			
			
			
			if(Physics.Raycast (ray,out hit,hitRange)){
				
				
				
				
				Transform particleClone = Instantiate(placeHolderEffect,hit.point,Quaternion.LookRotation(hit.normal)) as Transform;
				
				Destroy(particleClone.gameObject,2);
				
				hit.transform.SendMessage("applyDamage", damage,SendMessageOptions.DontRequireReceiver);
				
				
				
			}
			
			
			
		}
		
		
		if (Input.GetButtonDown ("Weapon1")) {
			
			weaponNumber = 1;
		}
		
		if (Input.GetButtonDown ("Weapon2")) {
			
			weaponNumber = 2;
		}
		
		if (Input.GetButtonDown ("Weapon3")) {
			
			weaponNumber = 3;
		}
		
		if (Input.GetButtonDown ("Weapon4")) {
			
			weaponNumber = 4;
		}
		
	}
	
	void gunEnabler(GameObject current){
		
		if (current == gun1) {
			
			gun1.SetActive	(true);
			gun2.SetActive (false);
			gun3.SetActive (false);
			gun4.SetActive (false);
			
		}
		if (current == gun2) {
			
			gun1.SetActive (false);
			gun2.SetActive (true);
			gun3.SetActive (false);
			gun4.SetActive (false);
			
		}
		if (current == gun3) {
			
			gun2.SetActive (false);
			gun1.SetActive (false);
			gun3.SetActive (true);
			gun4.SetActive (false);
			
		}
		if (current == gun4) {
			
			gun2.SetActive (false);
			gun3.SetActive (false);
			gun1.SetActive (false);
			gun4.SetActive (true);
			
		}
		
		
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
}

