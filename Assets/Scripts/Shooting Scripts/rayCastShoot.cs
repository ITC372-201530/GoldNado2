using UnityEngine;
using System.Collections;

public class rayCastShoot : MonoBehaviour {


	public float damage = 100.0f;
	public float hitRange = 100.0f;
	public float spreadFactor = 0.02f;

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
	
	}
	
	// Update is called once per frame
	void Update () {



		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2,0));

		Vector3 direction = transform.forward;
		direction.x += Random.Range (-spreadFactor, spreadFactor);
		direction.y += Random.Range (-spreadFactor, spreadFactor);
		direction.z += Random.Range (-spreadFactor, spreadFactor);


			if(Input.GetButtonDown("Fire1") && gameVariables.ammunition > 0){

			gameVariables.ammunition--;

				print("Weapon Number:"+weaponNumber);
				print("Ammunition:"+gameVariables.ammunition);


				switch(weaponNumber){

				case 1:
					placeHolderEffect = yellowEffect;
					break;
				case 2:
					placeHolderEffect = redEffect;
					break;
				case 3:
					placeHolderEffect = blueEffect;
					break;
				case 4:
					placeHolderEffect = greenEffect;
					break;
				default:
					placeHolderEffect = yellowEffect;
					break;

				}


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


	




		



	
}

