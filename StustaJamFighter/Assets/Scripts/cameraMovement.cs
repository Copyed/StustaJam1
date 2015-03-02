using UnityEngine;
using System.Collections;

public class cameraMovement : MonoBehaviour {

	public Transform leftBorder;
	public Transform rightBorder;

	public float inverseCameraSize = 2.3f;
	public float minSize = 3f;
	public float hoehenfaktor = 2f;
	public float heightoffset = -1f;


	private Vector3 lB;
	private Vector3 rB;

	private Player[] players;

	// Use this for initialization
	void Start () {
		players = GameManager.instance.players;
		Debug.Log (players.Length);
		DetermineBorders ();
	}

	void DetermineBorders(){
		lB = leftBorder.position + new Vector3 (2f*camera.orthographicSize, transform.position.y, transform.position.z);
		rB = rightBorder.position + new Vector3 (-2f*camera.orthographicSize, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		//Determine center of players
		float xAverage = 0f;
		foreach (var item in players) {
			xAverage += item.gameObject.transform.position.x;
		}
		xAverage *= 0.5f;
		
		DetermineBorders ();
		xAverage = Mathf.Max (xAverage, lB.x);
		xAverage = Mathf.Min (xAverage, rB.x);

		float leftPlayerx = Mathf.Min (players [0].transform.position.x, players [1].transform.position.x);
		float rightPlayerx = Mathf.Max (players [0].transform.position.x, players [1].transform.position.x);
		float sizeBorder1 = Mathf.Max (leftPlayerx, lB.x);
		float sizeBorder2 = Mathf.Min (rightPlayerx, rB.x);
		Debug.Log (sizeBorder1);
		//if (sizeBorder1 > 0f)
		//	return;

		float newSize = Mathf.Abs (leftPlayerx - rightPlayerx)/inverseCameraSize;
		Debug.Log ("newsize " + newSize);
		changeSize(Mathf.Max(minSize,newSize));


		transform.position = new Vector3 (xAverage, transform.position.y, transform.position.z);

	

	}

	private void changeSize(float amount){
		//float temp = camera.orthographicSize * amount;
		transform.position = new Vector3 (transform.position.x, hoehenfaktor * amount + heightoffset, transform.position.z);
		camera.orthographicSize = amount;
	}

	public void plusSize(){
		changeSize (1.1f);
	}
	public void minusSize(){
		changeSize (0.9f);
	}
	

}
