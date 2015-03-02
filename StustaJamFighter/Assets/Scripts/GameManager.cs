using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//Singleton instance
	public static GameManager instance;
	
	public Transform Player1Prefab;
	public Transform Player2Prefab;
	
	//Wie lange bis ein neuer Gegner gespawned wird
	public float DyingTimer = 2.0f;

    public Player[] players;
    
    bool RoutineRunning = false;

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
		//camera = Camera.main;
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
		for( int i = 0; i < players.Length; i++ )
		{
			if(players[i] == null && RoutineRunning == false)
			{
				StartCoroutine("CoolDown",new Vector2(DyingTimer,i));
				
			}
		}
	
	}
	
	IEnumerator CoolDown(Vector2 DataVec)
	{
		float WaitingTime = DataVec.x;
		int Index = (int)DataVec.y;
		
		RoutineRunning = true;
		if(Index == 0)
		{
			yield return new WaitForSeconds(WaitingTime);
			Transform NuPlayer = Instantiate(Player2Prefab,new Vector3(0,0,0),Quaternion.identity) as Transform;
			players[Index] = NuPlayer.GetComponent<Player>();
			players[1].Enemy = players[Index];
		}
		else
		{
			yield return new WaitForSeconds(WaitingTime);
			Transform NuPlayer = Instantiate(Player1Prefab,new Vector3(0,0,0),Quaternion.identity) as Transform;
			players[Index] = NuPlayer.GetComponent<Player>();
			players[0].Enemy = players[Index];
		}
		RoutineRunning = false;
	}
}
