using UnityEngine;
using System.Collections;

public class rayCastShoot : MonoBehaviour {

	public Transform effect;
	public float damage = 100.0f;
	public float hitRange = 100.0f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2,0));

		if(Input.GetButtonDown("Fire1")){


			if(Physics.Raycast (ray,out hit,hitRange)){

				Transform particleClone = Instantiate(effect,hit.point,Quaternion.LookRotation(hit.normal)) as Transform;

				Destroy(particleClone.gameObject,2);

				hit.transform.SendMessage("applyDamage", damage,SendMessageOptions.DontRequireReceiver);



			}



		}



	
	}
}
