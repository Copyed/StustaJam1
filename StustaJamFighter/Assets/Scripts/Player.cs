using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float health = 100.0f;
    public float speed = 10.0f;

	private Animator animator;
	public Player Enemy;

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
	}
	
	public void Punch()
	{
		animator.SetTrigger ("punch");
	}
	
	public void HeavyPunch()
	{
		Debug.Log ("HEAVY PUNCH");
	}
	
	public void HighPunch()
	{
		Debug.Log ("HIGH PUNCH");
	}
	
	public void Kick()
	{
		Debug.Log ("KICK");
	}
	
	public void HeavyKick()
	{
		Debug.Log ("HEAVY KICK");
	}
	
	public void Block()
	{
		Debug.Log ("BLOCK");
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
}
