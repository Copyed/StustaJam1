using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float health = 100.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
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
}
