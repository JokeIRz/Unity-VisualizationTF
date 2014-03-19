using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Guide : MonoBehaviour
{
	public delegate void CGUI(GameObject g);
	public GameObject player;
	public Camera PlayerCamera;
	
	public delegate void CutsceneEvent();
	public event CutsceneEvent OnEnd;
	
	void Start()
	{
		player = GameObject.Find("Player");
		PlayerCamera = GameObject.Find ("Main Camera").GetComponent<Camera>();
	}
		
	public void newCutscene(string animationName, CGUI gui)
	{
		gameObject.GetComponent<Camera>().enabled = true;
		gameObject.animation.Play(animationName);
		
		player.GetComponent<NavMeshAgent>().Stop();
		
		gui(gameObject);
	}
	
	void OnWasherEnd()
	{
		OnEnd();
	}
	
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			OnWasherEnd();
		}
	}
}
