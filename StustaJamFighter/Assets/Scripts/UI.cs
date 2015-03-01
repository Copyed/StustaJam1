using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour {
    public Image healthBarLeft;
    public Image healthBarRight;

    public float healthBarScaling = 0.1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //healthBarLeft = GameManager.instance.players[0].health * healthBarScaling;
        //healthBarRight.flexibleWidth = GameManager.instance.players[1].health * healthBarScaling;
	}
}
