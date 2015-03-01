﻿using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {

    public Player playerLeft;
    public Player playerRight;

    public GameObject healthBarLeft;
    public GameObject healthBarRight;

    public float healthBarScaling = 0.1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        healthBarLeft.transform.localScale = new Vector3(playerLeft.health * healthBarScaling, 1.0f, 1.0f);
        healthBarRight.transform.localScale = new Vector3(playerRight.health * healthBarScaling, 1.0f, 1.0f);

	}
}