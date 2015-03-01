using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {

    public Player player1;
    public Player player2;

    public GameObject healthBar1;
    public GameObject healthBar2;

    public float healthBarScaling = 0.1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        healthBar1.transform.localScale = new Vector3(player1.health * healthBarScaling, 1.0f, 1.0f);
        healthBar2.transform.localScale = new Vector3(player2.health * healthBarScaling, 1.0f, 1.0f);

	}
}
