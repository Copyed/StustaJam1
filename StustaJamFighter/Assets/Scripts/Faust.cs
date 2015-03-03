using UnityEngine;
using System.Collections;

public class Faust : MonoBehaviour {

	Player MyPlayer;
	// Use this for initialization
	void Start () {
		
		MyPlayer = this.transform.parent.GetComponent<Player>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject != MyPlayer.gameObject)
		{
			//Debug.Log(other.name);
			MyPlayer.Enemy.HitbyFist();
		}
	}
}
