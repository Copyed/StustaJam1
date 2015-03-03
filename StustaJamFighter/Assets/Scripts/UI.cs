using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour {
    public RectTransform healthBarLeft;
    public RectTransform healthBarRight;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (GameManager.instance.players[1].health+" "+GameManager.instance.players[0].health);
	
		if(healthBarLeft != null)
		{
        	healthBarLeft.sizeDelta = new Vector2(GameManager.instance.players[1].health, 100.0f);
        }
        if(healthBarRight != null)
        {
            healthBarRight.sizeDelta = new Vector2(GameManager.instance.players[0].health, 100.0f);
		}
	}
}
