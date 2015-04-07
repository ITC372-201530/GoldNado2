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
	
	// Use this for initialization
	
	private CharacterController cc;
	
	void Start () {
		
		this.cc = GetComponent<CharacterController> ();
		
		Screen.lockCursor = true;
		
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
		
		
		
		//movement
		
		float mspeed = this.movementSpeed;
		
		if(Input.GetKey(KeyCode.LeftShift)) {
			
			mspeed +=this.sprintSpeed;
			
		}
		
		float fSpeed = Input.GetAxis("Vertical") *mspeed;
		
		float sSpeed = Input.GetAxis("Horizontal") *this.movementSpeed;
		
		
		
		this.vVelocity += Physics.gravity.y *Time.deltaTime;
		
		if(Input.GetButtonDown ("Jump") && this.cc.isGrounded) {
			
			this.vVelocity =this.jumpSpeed;
			
		}
		
		
		
		Vector3 speed = new Vector3(sSpeed, this.vVelocity, fSpeed);
		
		speed = this.transform.rotation * speed;		
		
		cc.Move (speed *Time.deltaTime);
		
	}
	
}