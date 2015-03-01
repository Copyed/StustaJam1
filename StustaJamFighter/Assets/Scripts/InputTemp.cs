﻿using UnityEngine;
using System.Collections;

// temporaly used for hopping around in the game world
// TODO: this script is temporal, please delete me.
public class InputTemp : MonoBehaviour {

    public Player player;
    public GameObject fist;
    public float speed = 10.0f;
    public float jump = 0.5f;

    public Vector3 fistStartPosition;
    public Vector3 fistPunchPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        player.transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical") * jump, 0.0f) * (Time.deltaTime * speed));
        if(Input.GetKeyDown(KeyCode.X))
        {
            fist.transform.localPosition = fistPunchPosition;
        }
        else
        {
            fist.transform.localPosition = fistStartPosition;
        }
	}
}
