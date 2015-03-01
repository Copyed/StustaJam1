using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//Singleton instance
	public static GameManager instance;

<<<<<<< HEAD
	[HideInInspector]public GameObject player1;
	[HideInInspector]public GameObject player2;
=======
    public Player[] players;
>>>>>>> ee29ccfe098ff60e4b080e0bb6751d593ee0befc

	// Use this for initialization
	void Awake () {
		if (instance == null) {
            instance = this;
            players = GameObject.FindObjectsOfType<Player>();
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
