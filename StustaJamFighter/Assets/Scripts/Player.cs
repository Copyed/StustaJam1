using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float health = 100.0f;
    
    public int PlayerNumber;
    
    public float PlayerSpeed = 10.0f;

	private Animator animator;
    public Player Enemy;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		
        //Findet den Gegner um ihn immer anzuvisieren
		foreach(Player player in GameManager.instance.players)
		{
            if (player != this.gameObject)
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
			
			//Links vom Gegner
			if(this.transform.position.x < Enemy.transform.position.x && this.transform.rotation.y != 0)
			{
				transform.rotation = new Quaternion(old.x,0,old.z,old.w);
	        }
			if(this.transform.position.x > Enemy.transform.position.x && this.transform.rotation.y != 180)
			{
				transform.rotation = new Quaternion(old.x,180,old.z,old.w);
			}
		}

	}

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collided with "+other.gameObject.name+" "+other.gameObject.tag);
        if(other.gameObject.tag == "Fist")
        {
            Debug.Log("You got fisted");
            health -= 10.0f;
        }
    }
	
	public void MovePlayer(float StickMove)
	{
		animator.SetFloat ("movSpeed", StickMove);
		Vector3 old = transform.position;
		transform.position = new Vector3(old.x + PlayerSpeed * StickMove * Time.deltaTime,old.y,old.z);
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
		Debug.Log ("PUNCH");
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
}
