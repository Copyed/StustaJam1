using UnityEngine;
using System.Collections;

public class FightSounds : MonoBehaviour {

	public AudioClip[] FightingSounds;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Hit()
	{
		int Index = Random.Range (0,6);
		audio.clip = FightingSounds[Index];
		audio.Play();
	}
	
	public void Die()
	{
		audio.clip = FightingSounds[7];
		audio.Play();
	}
}
