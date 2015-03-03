using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour {
    public RectTransform healthBarLeft;
    public RectTransform healthBarRight;

    public float factor = 1.85f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (GameManager.instance.players[1].health+" "+GameManager.instance.players[0].health);
	
		if(healthBarLeft != null)
		{
            healthBarLeft.pivot = new Vector2((GameManager.instance.players[1].health * (factor / -100.0f)) + factor, 0.5f);
        }
        if(healthBarRight != null)
        {
            healthBarRight.pivot = new Vector2((GameManager.instance.players[0].health * (factor / -100.0f)) + factor, 0.5f);
		}
	}
}
