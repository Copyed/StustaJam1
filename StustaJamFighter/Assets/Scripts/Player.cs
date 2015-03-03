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

    bool dead = false;
    
    public Transform[] PlushFetzen;

	// Use this for initialization
	void Start () {
        dead = false;
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
        if (dead)
            return;
	
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
        if (dead)
            return;
		animator.SetFloat ("movSpeed", StickMove);
		Vector3 old = transform.position;
		transform.position = new Vector3(old.x + speed * StickMove * Time.deltaTime,old.y,old.z);
		CheckForBlock(StickMove);
	}
	
	public void Jump()
    {
        if (dead)
            return;
		//Player Jump
        if (!inAir)
        {
            rigidbody2D.AddForce(new Vector2(0.0f, jump));
            inAir = true;
        }
		//animator.SetFloat("ySpeed",rigidbody2D.velocity.y);
		//Debug.Log (rigidbody2D.velocity.y);
	}
	
	public void Duck()
    {
        if (dead)
            return;
		Debug.Log ("DUCK "+Time.time);
		Ducking = true;
		animator.SetBool ("duck",Ducking);
	}
	
	public void Punch()
    {
        if (dead)
            return;
		animator.SetTrigger ("punch");
		SetLayer();
	}
	
	public void HeavyPunch()
    {
        if (dead)
            return;
		animator.SetTrigger("highPunch");
		SetLayer();
	}
	
	public void HighPunch()
    {
        if (dead)
            return;
		animator.SetTrigger ("highPunch");
		SetLayer();
	}
	
	public void Kick()
    {
        if (dead)
            return;
		Debug.Log ("KICK");
		SetLayer();
	}
	
	public void HeavyKick()
    {
        if (dead)
            return;
		Debug.Log ("HEAVY KICK");
		SetLayer();
	}
	
	public void Block()
    {
        if (dead)
            return;
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
        if (dead)
            return;
        dead = true;
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
        if (dead)
            return;
		Debug.Log ("HIT");
		SpawnPlush();
		GameObject.Find ("OtherSoundsSource").GetComponent<FightSounds>().Hit();
	
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
        if (dead)
            return;
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
        if (dead)
            return;
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
	
	public void SpawnPlush()
	{
		//Debug.Log ("I : "+this.transform.name+" spawned plush");
		Vector3 SpawnPos = new Vector3(transform.position.x,transform.position.y+1.0f,transform.position.z);
		//Quaternion Rot = new Quaternion(-90,0,0,1);
		Transform Pref = Instantiate (PlushFetzen[Random.Range(0,PlushFetzen.Length)],SpawnPos,Quaternion.identity) as Transform;
		Pref.Rotate(new Vector3(1,0,0),-90.0f);
		Pref.rigidbody.AddForce(Random.Range (-80.0f,80.0f),Random.Range(0.0f,50.0f),0);
		
	}
}
