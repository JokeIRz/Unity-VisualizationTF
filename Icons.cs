using UnityEngine;
using System.Collections;

public class Icons : MonoBehaviour
{
	public Hashtable icons = new Hashtable();
	public bool canGUI = true;
	
	void Start()
	{
		foreach(Transform child in transform)
			icons.Add(child, "<b><color=#000>" + child.name + "</color></b>");
	}
	
	void OnGUI()
	{		
		if(canGUI)
		{
			foreach(DictionaryEntry entry in icons)
			{
				Transform temp = entry.Key as Transform;
				GUI.Label(GUI2.GUI3D(Camera.main, temp.position, 200), entry.Value.ToString());
			}
		}
	}
}
