using UnityEngine;
using System.Collections;

public class CutsceneTrigger : MonoBehaviour
{
	public Guide guide;
	
	void Start()
	{
		guide = GameObject.Find ("CutsceneCamera").GetComponent<Guide>();
		
		guide.OnEnd += OnEnd;
	}
	
	public string animationName;
	GameObject camera;
	public bool canGUI = false;
	public bool used = false;
	public bool inside = false;
	
	public CutsceneController controller;
	
	void OnTriggerEnter(Collider other)
	{
		if(other.name == "Body")
		{
			camera = GameObject.Find("CutsceneCamera");
			
			if(!used)
			{
				used = true;
				
				camera.GetComponent<Guide>().newCutscene(animationName, delegate(GameObject g){
					//gets called at end of Guide.cs newCutsceneFunctions
					canGUI = true;
				});
				
				controller.OnStart();
			}
		}
	}
	
	void OnGUI()
	{
		if (canGUI)
			controller.gui ();
		
		if(used && inside)
			GUI.Label(new Rect(Screen.width/2, Screen.height - 200, 300, 25), "Press SPACE to replay cutscene");
	}
	
	void OnTriggerStay(Collider other) {		
        if(used)
		{
			if(Input.GetKeyUp(KeyCode.Space))
			{
				camera.GetComponent<Guide>().newCutscene(animationName, delegate(GameObject g){
					//gets called at end of Guide.cs newCutsceneFunctions
					canGUI = true;
				});
				
				controller.OnStart();
			}
		}
    }
	
	void OnTriggerExit(Collider other)
	{
		if(used) inside = false; 
	}
	
	void OnEnd()
	{
		canGUI = false;
		
		controller.OnEnd();
	}
}
