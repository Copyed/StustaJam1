using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	public MonoBehaviour Player1Controls;
	public MonoBehaviour Player2Controls;

	int NumControllers = 0;

	// Use this for initialization
	void Start () {
	
		string[] Joys = Input.GetJoystickNames();
		NumControllers = Joys.Length;
	
	}
	
	// Update is called once per frame
	void Update () {
	
		
	
		if(Input.anyKey)
		{
			//Ein Controller angemeldet
			if(NumControllers > 0){
	
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
			
			}
			
			////SECOND Controller
			if(NumControllers > 1){
			
				if(Input.GetButtonDown("2A"))
				{
					Debug.Log ("2A");
				}
				
				if(Input.GetButtonDown("2B"))
				{
					Debug.Log ("2B");
				}
				
				if(Input.GetButtonDown("2X"))
				{
					Debug.Log ("2X");
				}
				
				if(Input.GetButtonDown("2Y"))
				{
					Debug.Log ("2Y");
				}
				
				if(Input.GetButtonDown("2RightBack"))
				{
					Debug.Log ("2RightBack");
				}
				
				if(Input.GetButtonDown("2LeftBack"))
				{
					Debug.Log ("2LeftBack");
				}
				
				if(Input.GetButtonDown("2PressLeftJoystick"))
				{
					Debug.Log ("2Left Joystick pressed");
				}
				
				if(Input.GetButtonDown("2PressRightJoystick"))
				{
					Debug.Log ("2Right Joystick pressed");
				}
				
				if(Input.GetButtonDown("2Back"))
				{
					Debug.Log ("2Back");
				}
				
				if(Input.GetButtonDown("2Start"))
				{
					Debug.Log ("2Start");
				}
			}
			
		}

	}
}
