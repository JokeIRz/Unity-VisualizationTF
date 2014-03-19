using UnityEngine;
using System.Collections;

public class TransparencyController : MonoBehaviour {
	
	public Transform[] ObjectsToHide;
	public Transform Walls;
	public bool cutscene = false;
	
	void Update()
	{
		if(transform.position.x >= -11.5f)
		{
			if(!cutscene)
				SetTransparent();
			else
				ShowWalls();
		}
		else
		{
			SetOpaque();
		}
	}
	
	public void SetTransparent()
	{
		foreach(Transform t in ObjectsToHide)
		{
			t.gameObject.SetActive(false);
		}
		Walls.gameObject.renderer.material.color = new Color(187/255,165/255,141/255,0.5f);
	}
	
	public void SetOpaque()
	{
		foreach(Transform t in ObjectsToHide)
		{
			t.gameObject.SetActive(true);
		}
		Walls.gameObject.renderer.material.color = new Color(187/255,165/255,141/255,1f);
	}
	
	public void ShowWalls()
	{
		Walls.gameObject.renderer.material.color = new Color(0,0,0,1f);
	}
}
