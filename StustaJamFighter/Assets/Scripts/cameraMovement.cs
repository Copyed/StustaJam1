using UnityEngine;
using System.Collections;

public class cameraMovement : MonoBehaviour {

	public Transform leftBorder;
	public Transform rightBorder;

	public float inverseCameraSize = 2.3f;
	public float minSize = 3f;
    public float maxSize = 15f;
	public float hoehenfaktor = 2f;
	public float heightoffset = -1f;


	private float lB;
	private float rB;

	private Player[] players;

	// Use this for initialization
	void Start () {
		players = GameManager.instance.players;
		Debug.Log (players.Length);
		DetermineBorders ();
	}

	void DetermineBorders(){
		lB = leftBorder.position.x + camera.aspect*camera.orthographicSize;
		rB = rightBorder.position.x - camera.aspect*camera.orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {
		//Determine center of players
		float xAverage = 0f;
		/*foreach (var item in players) {
			xAverage += item.gameObject.transform.position.x;
		}*/
		
		for ( int i = 0; i < players.Length; i++ )
		{
			xAverage += players[i].gameObject.transform.position.x;
		}
		
		xAverage *= 0.5f;
		
		DetermineBorders ();
		xAverage = Mathf.Max (xAverage, lB);
		//Debug.Log ("lb " + lB);
		xAverage = Mathf.Min (xAverage, rB);

		float leftPlayerx = Mathf.Min (players [0].transform.position.x, players [1].transform.position.x);
		float rightPlayerx = Mathf.Max (players [0].transform.position.x, players [1].transform.position.x);

		float newSize = Mathf.Abs (leftPlayerx - rightPlayerx)/inverseCameraSize;
		changeSize(Mathf.Max(minSize,newSize));


		transform.position = new Vector3 (xAverage, transform.position.y, transform.position.z);

	}

	private void changeSize(float amount){
		//float temp = camera.orthographicSize * amount;
        amount = Mathf.Min(amount, maxSize);
		transform.position = new Vector3 (transform.position.x, amount + heightoffset, transform.position.z);
		camera.orthographicSize = amount;
	}

	public void plusSize(){
		changeSize (1.1f);
	}
	public void minusSize(){
		changeSize (0.9f);
	}
	

}
