using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetButtonDown("A"))
		{
			Debug.Log ("A");
		}
		
		if(Input.GetButtonDown("B"))
		{
			Debug.Log ("B");
		}
		
		if(Input.GetButtonDown("X"))
		{
			Debug.Log ("X");
		}
		
		if(Input.GetButtonDown("Y"))
		{
			Debug.Log ("Y");
		}
		
		if(Input.GetButtonDown("RightBack"))
		{
			Debug.Log ("RightBack");
		}
		
		if(Input.GetButtonDown("LeftBack"))
		{
			Debug.Log ("LeftBack");
		}
		
		if(Input.GetButtonDown("PressLeftJoystick"))
		{
			Debug.Log ("Left Joystick pressed");
		}
		
		if(Input.GetButtonDown("PressRightJoystick"))
		{
			Debug.Log ("Right Joystick pressed");
		}
		
		if(Input.GetButtonDown("Back"))
		{
			Debug.Log ("Back");
		}
		
		if(Input.GetButtonDown("Start"))
		{
			Debug.Log ("Start");
		}
		
		//Debug.Log (Input.GetAxis("LeftJoystickX")+" "+Input.GetAxis("LeftJoystickY"));
		
		//Debug.Log (Input.GetAxis("TriggerLeft")+" R: "+Input.GetAxis("TriggerRight"));
		
/*		if(Input.GetAxis("X"))
		{
			Debug.Log ("HEYOOOOO");
		}
		
		if (Input.GetAxis("L Trigger"))
		{ 
			Debug.Log ("Hopp");
		}*/
	
	}
}
