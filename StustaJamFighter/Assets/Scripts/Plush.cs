using UnityEngine;
using System.Collections;

public class Plush : MonoBehaviour {

	public float time = 5.0f;

	// Use this for initialization
	void Start () {
	
		StartCoroutine("WaitFor",time);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	IEnumerator WaitFor(float time)
	{
		yield return new WaitForSeconds(time);
		Destroy(this.gameObject);
	}
}
