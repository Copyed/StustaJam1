using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour {
    public GameObject healthBarLeft;
    public GameObject healthBarRight;

    public float healthBarScaling = 0.1f;

	// Use this for initialization
	void Start () {
        Debug.Log("yeah");
	}
	
	// Update is called once per frame
	void Update () {
        healthBarLeft.transform.localScale = new Vector3(GameManager.instance.players[0].health * healthBarScaling, 1.0f, 1.0f);
        healthBarRight.transform.localScale = new Vector3(GameManager.instance.players[1].health * healthBarScaling, 1.0f, 1.0f);
	}
}
