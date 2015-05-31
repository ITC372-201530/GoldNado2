using UnityEngine;

using System.Collections;





public class playerController : MonoBehaviour {
	
	
	
	public float movementSpeed =10.0f;
	
	public float sprintSpeed =15.0f;
	
	public float mouseSpeed =2.0f;
	
	public float upDownRange =30.0f;
	
	public float jumpSpeed =7.0f;
	
	private float vRotation =0.0f;
	
	private float vVelocity = 0.0f;

	private float fSpeed = 0.0f;

	private float sSpeed = 0.0f;

	public AudioClip pant1;
	public AudioClip pant2;
	public AudioClip pant3;
	public AudioClip pant4;
	public AudioClip jump1;
	public AudioClip jump2;
	public AudioClip jump3;
	public AudioClip jump4;

	private AudioSource source;

	private int mainTimer = 0;
	private int shootTimer = 0;
	public int pantTimer = 5;

	private bool canPlay = true;
	
	// Use this for initialization
	
	private CharacterController cc;
	
	void Start () {
		
		this.cc = GetComponent<CharacterController> ();
		
		Screen.lockCursor = true;
		
	}

	void Awake(){
		
		source = GetComponent<AudioSource> ();
	}


	
	
	
	// Update is called once per frame
	
	void Update () {
		
		//rotation
		
		float rotX = Input.GetAxis ("Mouse X") *this.mouseSpeed;
		
		this.transform.Rotate (0, rotX, 0);
		
		
		
		this.vRotation -=Input.GetAxis ("Mouse Y") *this.mouseSpeed;
		
		this.vRotation = Mathf.Clamp (this.vRotation, -this.upDownRange, this.upDownRange);
		
		Camera.main.transform.localRotation = Quaternion.Euler (this.vRotation, 0, 0);

		//float rotY = Input.GetAxis ("Mouse Y") *this.mouseSpeed;
		
		//this.transform.Rotate (rotY, 0, 0);





		if (mainTimer >= shootTimer + pantTimer ) {
			
			canPlay = true;
		}





		
		
		
		//movement
		
		float mspeed = this.movementSpeed;
		
		if(Input.GetKey(KeyCode.LeftShift)) {
			
			mspeed +=this.sprintSpeed;



			if(canPlay){

				switch(Random.Range (0,4)){
					
				case 0:
					source.PlayOneShot (pant1, 1.0f);
					shootTimer = mainTimer;
					canPlay = false;

					break;
				case 1:
					source.PlayOneShot (pant2, 1.0f);
					shootTimer = mainTimer;
					canPlay = false;

					break;
				case 2:
					source.PlayOneShot (pant3, 1.0f);
					shootTimer = mainTimer;
					canPlay = false;

					break;
				case 3:
					source.PlayOneShot (pant4, 1.0f);
					shootTimer = mainTimer;
					canPlay = false;

					break;
					
				default:

					shootTimer = mainTimer;
					canPlay = false;

					break;
					
					
				}







			}



			
		}

		//if (this.cc.isGrounded) {
			fSpeed = Input.GetAxis ("Vertical") * mspeed;
		
			sSpeed = Input.GetAxis ("Horizontal") * this.movementSpeed;
		//}
		
		
		
		this.vVelocity += Physics.gravity.y *Time.deltaTime;
		
		if(Input.GetButtonDown ("Jump") && this.cc.isGrounded) {

			switch(Random.Range (0,4)){

			case 0:
				source.PlayOneShot (jump1, 1.0f);
				break;
			case 1:
				source.PlayOneShot (jump2, 1.0f);
				break;
			case 2:
				source.PlayOneShot (jump3, 1.0f);
				break;
			case 3:
				source.PlayOneShot (jump4, 1.0f);
				break;

			default:
				break;


			}

			

			
			this.vVelocity =this.jumpSpeed;
			
		}
		
		
		
		Vector3 speed = new Vector3(sSpeed, this.vVelocity, fSpeed);
		
		speed = this.transform.rotation * speed;		
		
		cc.Move (speed *Time.deltaTime);
		
	}
	
}