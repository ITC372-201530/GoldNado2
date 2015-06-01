using UnityEngine;
using System.Collections;

public class windSound : MonoBehaviour {
	
	public AudioClip[] windClips = new AudioClip[10];
	public waveController waveCont;
	private AudioSource windSource;
	
	private float lowPitch = 0.75f;
	private float highPitch = 1.5f;
	
	
	void Awake()
	{
		windSource = GetComponent<AudioSource> ();
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate()
	{
		//if waveOn;
		if (waveCont.waveOn) 
		{
			int clipIndex = (int)Mathf.Round (Random.Range (1, 10));
			
			windSource.pitch = Random.Range (lowPitch, highPitch);
			windSource.PlayOneShot (windClips [clipIndex], 1);
		}
	}
}