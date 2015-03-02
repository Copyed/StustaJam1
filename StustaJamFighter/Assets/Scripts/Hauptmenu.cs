using UnityEngine;
using System.Collections;

public class Hauptmenu : MonoBehaviour {

	bool VorhangOffen = false;
	
	private Animator animator;

	// Use this for initialization
	void Start () {
	
		animator = this.GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(VorhangOffen == false && Input.GetKeyDown("u"))
		{
			VorhangOffen = true;
			animator.SetBool("VorhangOffen",true);
		}
	
	}
}
