using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//Singleton routine
	public GameManager instance;

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
