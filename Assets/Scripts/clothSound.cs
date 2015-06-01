using UnityEngine;
using System.Collections;

public class clothSound : MonoBehaviour {
	
	
	public AudioClip[] clothClips = new AudioClip[12];
	public waveController waveCont;
	private AudioSource source;
	
	private float lowPitch = 0.75f;
	private float highPitch = 1.5f;
	
	void Awake()
	{
		source = GetComponent<AudioSource> ();
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate ()
	{
		//if waveOn;
		if (waveCont.waveOn) 
		{
			int clipIndex = (int)Mathf.Round (Random.Range (1, 12));
			
			source.pitch = Random.Range (lowPitch, highPitch);
			source.PlayOneShot (clothClips [clipIndex], 1);
		}
		
	}
}