using UnityEngine;
using System.Collections;

public class Cutscene_Wash : CutsceneController {

	public override void gui()
	{
		GUI.Label(GUI2.GUI3D(
			GameObject.Find ("CutsceneCamera").GetComponent<Camera>(),
			GameObject.Find ("Tag").transform.position,
			200, 20),
			"2. Put hair net on here"
		);
		
		GUI.Label(GUI2.GUI3D(
			GameObject.Find ("CutsceneCamera").GetComponent<Camera>(),
			GameObject.Find ("WashTag").transform.position,
			200, 20),
			"3. Wash hands thoroughly here"
		);
		
		GUI.Label(GUI2.GUI3D(
			GameObject.Find ("CutsceneCamera").GetComponent<Camera>(),
			GameObject.Find ("ShoeTag").transform.position,
			200, 20),
			"1. Replace yours shoes here"
		);
	}
	
	public override void OnStart()
	{
		player.GetComponent<TransparencyController>().cutscene = true;
		icons.canGUI = false;
		
		player.transform.Find("Body").renderer.enabled = false;
	}
	
	public override void OnEnd()
	{
		player.SetActive(true);
		PlayerCamera.enabled = true;
		CutsceneCamera.enabled = false;
		
		player.transform.position = new Vector3(-3.89053f,0,-16.55895f);
		
		player.GetComponent<TransparencyController>().cutscene = false;
		icons.canGUI = true;
		
		player.transform.Find("Body").renderer.enabled = true;
	}
}
