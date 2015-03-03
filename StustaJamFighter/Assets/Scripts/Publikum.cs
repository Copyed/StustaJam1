using UnityEngine;
using System.Collections;

public class Publikum : MonoBehaviour {

	public AudioClip[] ChatterSounds;

	// Use this for initialization
	void Start () {
	
		audio.clip = ChatterSounds[0];
		audio.Play();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void ChangeToLoud()
	{
		audio.clip = ChatterSounds[1];
		audio.volume = 0.2f;
		audio.Play();
	}
}
