using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	public Player Player1Controls;
	public Player Player2Controls;
	
	public float ErrorTolerance = 0.2f;
	//Wie weit nach rechts/links darf ich beim "NachObenLenken" kommen um noch zu jumpen
	public float JumpTolerance = 0.2f;

	int NumControllers = 0;

	// Use this for initialization
	void Start () {
	
		string[] Joys = Input.GetJoystickNames();
		NumControllers = Joys.Length;
		
	
	}

	
	// Update is called once per frame
	void Update () {

		CheckAxis();
	
		if(Input.anyKey)
		{
			//Ein Controller angemeldet
			if(NumControllers > 0){
			
	
				if(Input.GetButtonDown("A"))
				{
					Debug.Log ("A");					
					Player1Controls.Kick ();
				}
				
				if(Input.GetButtonDown("B"))
				{
					Debug.Log ("B");
					Player1Controls.HeavyKick();
				}
				
				if(Input.GetButtonDown("X"))
				{
					Debug.Log ("X");
					Player1Controls.Punch();
				}
				
				if(Input.GetButtonDown("Y"))
				{
					Debug.Log ("Y");
					Player1Controls.HeavyPunch();
				}
				
				if(Input.GetButtonDown("RightBack"))
				{
					Debug.Log ("RightBack");
					Player1Controls.HighPunch();
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
	
	
	
	float CheckforError(float AxisInput)
	{
		if(AxisInput < -ErrorTolerance || AxisInput > ErrorTolerance)
		{
			return AxisInput;
		}
		else
		{
			return 0;
		}
	}
	
	public void CheckAxis()
	{
		if(NumControllers > 0)
		{
									
			if(CheckforError(Input.GetAxis("LeftJoystickX")) != 0)
			{
				Player1Controls.MovePlayer(Input.GetAxis("LeftJoystickX"));
			}
			
			if(CheckforError(Input.GetAxis ("LeftJoystickY")) != 0)
			{
				if(Input.GetAxis("LeftJoystickY")<0)
				{
					if((Mathf.Abs (Input.GetAxis("LeftJoystickX"))) < JumpTolerance)
					{
						Player1Controls.Jump();
					}
				}
				if(Input.GetAxis("LeftJoystickY")>0)
				{
					if((Mathf.Abs (Input.GetAxis("LeftJoystickX"))) < JumpTolerance*2)
					{
						Player1Controls.Duck();
					}
				}
			}
			
		}
		
		if(NumControllers > 1)
		{
			
			if(CheckforError(Input.GetAxis("2LeftJoystickX")) != 0)
			{
				Player2Controls.MovePlayer(Input.GetAxis("2LeftJoystickX"));
			}
			
			if(CheckforError(Input.GetAxis ("2LeftJoystickY")) != 0)
			{
				if((Mathf.Abs (Input.GetAxis("2LeftJoystickX"))) < JumpTolerance)
				{
					Player2Controls.Jump();
				}
			}
			
		}
	}
	

}
