using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    public float health = 100.0f;
    public float speed = 10.0f;

	private Animator animator;
	public Player Enemy;
	
	public bool Ducking = false;


	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator> ();
        //Findet den Gegner um ihn immer anzuvisieren
		foreach(Player player in GameManager.instance.players)
		{
           		 if (player != this)
			{
                		Enemy = player;
            		}
		}
		
		
		CircleCollider2D[] Arr = GetComponents<CircleCollider2D>();
		foreach(CircleCollider2D Col in Arr)
		{
			Col.enabled = false;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Enemy != null)
		{
			Quaternion old = transform.rotation;
			
			// Links vom Gegner
			if(this.transform.position.x < Enemy.transform.position.x && this.transform.rotation.y != 0)
			{
				transform.rotation = new Quaternion(old.x,0,old.z,old.w);
	        }
            // Rechts vom Gegner
			if(this.transform.position.x > Enemy.transform.position.x && this.transform.rotation.y != 180)
			{
				transform.rotation = new Quaternion(old.x,180,old.z,old.w);
			}
		}

	}

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collided with "+other.gameObject.name+" "+other.gameObject.tag);
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collided with " + other.gameObject.name + " " + other.gameObject.tag);
    }
	
	public void MovePlayer(float StickMove)
	{
		animator.SetFloat ("movSpeed", StickMove);
		Vector3 old = transform.position;
		transform.position = new Vector3(old.x + speed * StickMove * Time.deltaTime,old.y,old.z);
		CheckForBlock(StickMove);
	}
	
	public void Jump()
	{
		//Player Jump
		Debug.Log ("JUMP "+Time.time);
	}
	
	public void Duck()
	{
		Debug.Log ("DUCK "+Time.time);
		Ducking = true;
	}
	
	public void Punch()
	{
		animator.SetTrigger ("punch");
		SetLayer();
	}
	
	public void HeavyPunch()
	{
		animator.SetTrigger("highpunch");
		SetLayer();
	}
	
	public void HighPunch()
	{
		animator.SetTrigger ("highPunch");
		SetLayer();
	}
	
	public void Kick()
	{
		Debug.Log ("KICK");
		SetLayer();
	}
	
	public void HeavyKick()
	{
		Debug.Log ("HEAVY KICK");
		SetLayer();
	}
	
	public void Block()
	{
		Debug.Log ("BLOCK");
	}
	
	//Linker Joystick im Ruhezustand
	public void LeftAxisReleased()
	{
		Ducking = false;
	}
	
	//Erhält die MoveDirection und prüft ob wir uns vom Gegner wegbewegen um zu blocken
	public void CheckForBlock(float MoveDir)
	{
		if(Enemy != null)
		{
			//Gegner ist rechts von mir
			if(Enemy.transform.position.x > this.transform.position.x && MoveDir < 0)
			{
				Block();
			}
			//Gegner ist links von mir
			else if (Enemy.transform.position.x < this.transform.position.x && MoveDir > 0)
			{
				Block();
			}
		}
	}
	
	//Wird aufgerufen wenn man zuschlägt um VOR dem Gegner zu erscheinen
	public void SetLayer()
	{
		if(Enemy.renderer.sortingOrder >= this.renderer.sortingOrder)
		{
			this.renderer.sortingOrder = Enemy.renderer.sortingOrder + 1;
		}
	}
}
