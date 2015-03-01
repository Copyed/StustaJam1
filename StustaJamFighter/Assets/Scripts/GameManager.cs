using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//Singleton routine
	public static GameManager instance;

	[HideInInspector]public GameObject player1;
	[HideInInspector]public GameObject player2;

	// Use this for initialization
	void Awake () {
		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
