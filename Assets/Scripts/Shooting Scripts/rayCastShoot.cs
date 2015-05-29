using UnityEngine;
using System.Collections;

public class rayCastShoot : MonoBehaviour {
	
	
	private float damage = 100.0f;

	private float hitRange =100.0f;
	public float revolverRange = 50.0f;
	public float rifleRange = 100.0f;
	public float shotgunRange = 25.0f;

	public float spreadFactor = 0.02f;
	public int shotgunPellets = 10;

	private int mainTimer = 0;
	private int shootTimer = 0;
	public int revolverTimer = 5;
	public int rifleTimer = 10;
	public int shotgunTimer = 7;
	private int placeHolderTimer = 5;
	private bool canShoot = true;


	
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

	public AudioClip revolverShot;
	public AudioClip rifleShot;
	public AudioClip shotgunShot;
	public AudioClip noAmmo;
	private AudioClip placeHolderShot;

	private AudioSource source;
	
	//public GameObject[] weapons;
	//public GameObject currentWeapon;
	
	int weaponNumber = 1;
	
	// Use this for initialization
	void Start () {
		
		gameVariables.ammunition = 10;
		currentGun = gun1;
		gunEnabler (currentGun);
		
	}

	void Awake(){

		source = GetComponent<AudioSource> ();
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
			placeHolderShot = revolverShot;
			placeHolderTimer = revolverTimer;
			hitRange = revolverRange;
			break;
		case 2:
			currentGun = gun2;
			gunEnabler(currentGun);
			placeHolderEffect = redEffect;
			placeHolderShot = rifleShot;
			placeHolderTimer = rifleTimer;
			hitRange = rifleRange;
			break;
		case 3:
			currentGun = gun3;
			gunEnabler(currentGun);
			placeHolderEffect = blueEffect;
			placeHolderShot = shotgunShot;
			placeHolderTimer = shotgunTimer;
			hitRange = shotgunRange;
			break;
		
		default:
			currentGun = gun1;
			gunEnabler(currentGun);
			placeHolderEffect = yellowEffect;
			break;
			
		}


		if (mainTimer >= shootTimer + placeHolderTimer) {

			canShoot = true;
		}
		
		if (Input.GetButtonDown ("Fire1") && gameVariables.ammunition > 0 && currentGun != gun3 && canShoot) {
			
			gameVariables.ammunition--;
			
			print ("Weapon Number:" + weaponNumber);
			print ("Ammunition:" + gameVariables.ammunition);
			

			source.PlayOneShot (placeHolderShot, 1.0f);
			shootTimer = mainTimer;
			canShoot = false;
			
			if (Physics.Raycast (ray, out hit, hitRange)) {
				
				
				

				Transform particleClone = Instantiate (placeHolderEffect, hit.point, Quaternion.LookRotation (hit.normal)) as Transform;
				
				Destroy (particleClone.gameObject, 2);
				
				hit.transform.SendMessage ("applyDamage", damage, SendMessageOptions.DontRequireReceiver);
				
				
				
			}
			
			
			
		} else if (Input.GetButtonDown ("Fire1") && gameVariables.ammunition > 0 && currentGun == gun3 && canShoot) {
			
			gameVariables.ammunition--;
			
			print ("Weapon Number:" + weaponNumber);
			print ("Ammunition:" + gameVariables.ammunition);


			source.PlayOneShot (placeHolderShot, 1.0f);
			canShoot = false;
			shootTimer = mainTimer;

			Vector3 gunForward = Camera.main.transform.forward;
			gunForward.y  = gunForward.y + 0.1f;
			var gunPos = transform.position;
			var cachedTrans = transform;
			Vector3 middleScreen = new Vector3(Screen.width/2,Screen.height/2,0);

			for(int i = 0; i < shotgunPellets; i++)
			{
				var bulletVec = gunForward + cachedTrans.TransformDirection(
					new Vector3(
					Random.Range (-spreadFactor, spreadFactor),
					Random.Range (-spreadFactor, spreadFactor),
					0));

				if (Physics.Raycast (gunPos, bulletVec, out hit, hitRange)) {
					
					
					
					
					Transform particleClone = Instantiate (placeHolderEffect, hit.point, Quaternion.LookRotation (hit.normal)) as Transform;
					
					Destroy (particleClone.gameObject, 2);
					
					hit.transform.SendMessage ("applyDamage", damage, SendMessageOptions.DontRequireReceiver);
					
					
					
				}



			}










		}else if(Input.GetButtonDown ("Fire1") && gameVariables.ammunition == 0 && canShoot){

			source.PlayOneShot(noAmmo,1.0f);
			canShoot = false;
			shootTimer = mainTimer;

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

	void FixedUpdate(){
		++mainTimer;
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
}