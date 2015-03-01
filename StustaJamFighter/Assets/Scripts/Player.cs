﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float health = 100.0f;
    
    public int PlayerNumber;
    
    public float PlayerSpeed = 10.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void MovePlayer(float StickMove)
	{
		Vector3 old = transform.position;
		transform.position = new Vector3(old.x + PlayerSpeed * StickMove * Time.deltaTime,old.y,old.z);
	}
	
	public void Jump()
	{
		//Player Jump
		Debug.Log ("JUMP "+Time.time);
	}
	
	public void Punch()
	{
		Debug.Log ("PUNCH");
	}
	
	public void HeavyPunch()
	{
		Debug.Log ("HEAVY PUNCH");
	}
	
	public void HighPunch()
	{
		Debug.Log ("HIGH PUNCH");
	}
	
	public void Kick()
	{
		Debug.Log ("KICK");
	}
	
	public void HeavyKick()
	{
		Debug.Log ("HEAVY KICK");
	}
}