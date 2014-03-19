using UnityEngine;
using System.Collections;

public class CutsceneController : MonoBehaviour
{
	public GameObject player;
	public Camera PlayerCamera;
	public Camera CutsceneCamera;
	
	public Icons icons;
	
	void Start()
	{
		player = GameObject.Find("Player");
		PlayerCamera = GameObject.Find ("Main Camera").GetComponent<Camera>();
		CutsceneCamera = GameObject.Find("CutsceneCamera").GetComponent<Camera>();
		icons = GameObject.Find("Icons").GetComponent<Icons>();
	}
	
	public virtual void gui() {}
	public virtual void OnEnd() {}
	public virtual void OnStart(){}
}
