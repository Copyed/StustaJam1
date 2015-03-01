using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//Singleton instance
	public static GameManager instance;

	public GameObject player1;
	public GameObject player2;
    public Player[] players;

	// Use this for initialization
	void Awake () {
		if (instance == null) {
            instance = this;
            //players = GameObject.FindObjectsOfType<Player>();
            Debug.Log("Found "+players.Length+" players.");
        }
        else {
            Destroy(gameObject);
        }
			

		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
