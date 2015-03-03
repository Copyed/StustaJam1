using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Hauptmenu : MonoBehaviour {

	bool VorhangOffen = false;
	bool ShowingCredits = true;
	
	private Animator animator;
	
	public GameObject Credits;
	
	public List<Image> Imgs = new List<Image>();
	public List<Text> Txts = new List<Text>();
	public List<Button> Buts = new List<Button>();
	public List<GameObject> CredTeile = new List<GameObject>();

	// Use this for initialization
	void Start () {
	
		animator = this.GetComponent<Animator>();
		for(int i = 0; i < Credits.transform.childCount; i++)
		{
			Image img = Credits.transform.GetChild(i).GetComponent<Image>();
			Text txt = Credits.transform.GetChild (i).GetComponent<Text>();
			Button but = Credits.transform.GetChild(i).GetComponent<Button>();
			CredTeile.Add (Credits.transform.GetChild(i).gameObject);
			
			if(img!=null)
			{
				Imgs.Add (img);
				img.enabled = false;
			}
			if(txt!=null)
			{
				Txts.Add (txt);
				txt.enabled = false;
			}
			if(but!=null)
			{
				Buts.Add (but);
				but.enabled = false;
			}
			ShowingCredits = false;
			CredTeile[i].SetActive(false);
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
		//Debug.Log (VorhangOffen);
	
        if(Input.GetKeyDown("u"))
        {
            	if(VorhangOffen == false)
	            {
		            VorhangOffen = true;
					Publikum PublikumScript = GameObject.Find ("PublikumSound").GetComponent<Publikum>();
					PublikumScript.ChangeToLoud();
		            animator.SetBool("VorhangOffen",true);
                }
                else
                {
                    LoadLevel1();
                }
        }
	
	
	

			
			
			if(Input.GetButtonDown("A"))
			{				
			}
			
			if(Input.GetButtonDown("B"))
			{
			}
			
			if(Input.GetButtonDown("X"))
			{
			}
			
			if(Input.GetButtonDown("Y"))
			{
			}
			
			if(Input.GetButtonDown("RightBack"))
			{
			}
			
			if(Input.GetButtonDown("LeftBack"))
			{
			}
			
			if(Input.GetButtonDown("PressLeftJoystick"))
			{
			}
			
			if(Input.GetButtonDown("PressRightJoystick"))
			{
			}
			
			if(Input.GetButtonDown("Back"))
			{
				Debug.Log ("BACK");
				ToggleCredits();
			}
			
			if(Input.GetButtonDown("Start"))
			{
				if(VorhangOffen == false)
				{
					VorhangOffen = true;
					Publikum PublikumScript = GameObject.Find ("PublikumSound").GetComponent<Publikum>();
					PublikumScript.ChangeToLoud();
					animator.SetBool("VorhangOffen",true);
				}
				else
				{
					LoadLevel1();
				}
			}
			
		
	
	}
	
	public void LoadLevel1()
	{
		Application.LoadLevel (1);
	}
	
	public void ToggleCredits()
	{
		ShowingCredits = !ShowingCredits;
		Debug.Log ("TOGGLING CREDITS");
		if(ShowingCredits == false)
		{
			foreach(Image I in Imgs)
			{
				Debug.Log ("Found an IMage");
				I.enabled = false;
			}
			foreach(Text T in Txts)
			{
				Debug.Log ("Found a TXT");
				T.enabled = false;
			}
			foreach(Button B in Buts)
			{
				Debug.Log ("Found a Button");
				B.enabled = false;
			}
		}
		if(ShowingCredits == true)
		{
			foreach(Image I in Imgs)
			{
				Debug.Log ("Found an IMage");
				I.enabled = true;
			}
			foreach(Text T in Txts)
			{
				Debug.Log ("Found a TXT");
				T.enabled = true;
			}
			foreach(Button B in Buts)
			{
				Debug.Log ("Found a Button");
				B.enabled = true;
			}
			foreach(GameObject G in CredTeile)
			{
				G.SetActive(true);
			}
		}
	}
	

}
