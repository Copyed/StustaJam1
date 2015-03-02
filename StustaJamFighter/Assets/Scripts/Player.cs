using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    public float health = 100.0f;
    public float speed = 10.0f;
    public float jump = 200.0f;

	private Animator animator;
	public Player Enemy;
	
	public bool Ducking = false;
	public bool Blocking = false;
    public bool inAir;

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
	}
	
	// Update is called once per frame
	void Update () {
	
	
		if(Enemy != null)
		{
            faceEnemy();
		}
		
		if(health <= 0)
		{
			Die();
		}
		if (inAir)
			animator.SetFloat("ySpeed",rigidbody2D.velocity.y);
		

        if (rigidbody2D.velocity.y < 0)
        {
            Debug.Log("Falling " + Time.time);
        }

	}

    void faceEnemy()
    {
        Quaternion old = transform.rotation;

        // Links vom Gegner
        if (this.transform.position.x < Enemy.transform.position.x && this.transform.rotation.y != 0)
        {
            transform.rotation = new Quaternion(old.x, 0, old.z, old.w);
        }
        // Rechts vom Gegner
        if (this.transform.position.x > Enemy.transform.position.x && this.transform.rotation.y != 180)
        {
            transform.rotation = new Quaternion(old.x, 180, old.z, old.w);
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground") inAir = false;
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
        if (!inAir)
        {
            rigidbody2D.AddForce(new Vector2(0.0f, jump));
            inAir = true;
        }
		//animator.SetFloat("ySpeed",rigidbody2D.velocity.y);
		Debug.Log (rigidbody2D.velocity.y);
	}
	
	public void Duck()
	{
		Debug.Log ("DUCK "+Time.time);
		Ducking = true;
		animator.SetBool ("duck",Ducking);
	}
	
	public void Punch()
	{
		animator.SetTrigger ("punch");
		SetLayer();
	}
	
	public void HeavyPunch()
	{
		animator.SetTrigger("highPunch");
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
		animator.SetBool ("block", true);
		//Debug.Log ("BLOCK");
	}
	
	//Linker Joystick im Ruhezustand
	public void LeftAxisReleased()
	{
		Ducking = false;
		Blocking = false;
		animator.SetBool ("block", Blocking);
		animator.SetBool("duck",Ducking);
	}
	
	public void Die()
	{
		animator.SetTrigger ("die");
		//does not work    	this.enabled = false;
		//GetComponent<BoxCollider2D> ().enabled = false;
		Invoke ("DieDestroy", 5.0f);
	}

	public void DieDestroyer(){
		Destroy (this.gameObject);
	}
	
	public void HitbyFist()
	{
		animator.SetTrigger ("isHit");
		if(Blocking)
		{
			health -= 3.0f;
		}
		else
		{
			health-= 9.0f;
		}
	}
	
	public void HitbyFeet()
	{
		if(Blocking)
		{
			health -= 4.0f;
		}
		else
		{
			health-=12.0f;
		}
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
				Blocking = true;
			}
			//Gegner ist links von mir
			else if (Enemy.transform.position.x < this.transform.position.x && MoveDir > 0)
			{
				Block();
				Blocking = true;
			}
			else
			{
				Blocking = false;
			}
		}
		else
		{
			Blocking = false;
		}
		animator.SetBool ("block", Blocking);
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
