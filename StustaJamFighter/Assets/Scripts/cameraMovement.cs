using UnityEngine;
using System.Collections;

public class cameraMovement : MonoBehaviour {

	public Transform leftBorder;
	public Transform rightBorder;

	public float inverseCameraSize = 2.3f;
	public float minSize = 3f;
	public float hoehenfaktor = 2f;

	private Vector3 lB;
	private Vector3 rB;

	private GameObject[] players;

	// Use this for initialization
	void Start () {
		players = GameObject.FindGameObjectsWithTag ("Player");
		lB = leftBorder.position + new Vector3 (2f*camera.orthographicSize, 0f, transform.position.z);
		rB = rightBorder.position + new Vector3 (-2f*camera.orthographicSize, 0f, transform.position.z);
	
	}
	
	// Update is called once per frame
	void Update () {

		float newSize = Mathf.Abs (players [0].transform.position.x - players [1].transform.position.x) /inverseCameraSize;
		if (newSize > 9.2f)
			transform.position = new Vector3 (transform.position.x, 1f + (newSize - 9.2f) * hoehenfaktor, transform.position.z);
		camera.orthographicSize = newSize > minSize ? newSize : minSize;

		lB = leftBorder.position + new Vector3 (2f*camera.orthographicSize, 0f, transform.position.z);
		rB = rightBorder.position + new Vector3 (-2f*camera.orthographicSize, 0f, transform.position.z);


		//Determine center of players
		float xAverage = 0f;
		foreach (var item in players) {
			xAverage += item.transform.position.x;
		}
		xAverage /= (float)players.Length;

		//set camera to midpoint
		if (xAverage < lB.x)
			transform.position = lB;
		else if (xAverage > rB.x)
			transform.position = rB;
		else
			transform.position = new Vector3 (xAverage, transform.position.y, transform.position.z);



	}
}
