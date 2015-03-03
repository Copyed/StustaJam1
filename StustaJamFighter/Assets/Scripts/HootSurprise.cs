using UnityEngine;
using System.Collections;

public class HootSurprise : MonoBehaviour {

	private Animator anim;

	// Use this for initialization
	void Start () {
	
		anim = this.GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	
		
		if(Input.GetButtonDown("Y"))
		{
			Debug.Log ("HOOT");
			anim.SetTrigger("Hoot");
		}
	
	}
}
