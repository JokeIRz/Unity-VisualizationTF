using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public Camera camera;
	float newSize = 7;
	float oldSize = 7;
	public Transform body;
	
	public NavMeshAgent agent;
	public GameObject movePreview;
	
	Guide scene;
	
	void Start()
	{
		oldSize = camera.orthographicSize;
		agent = GetComponent<NavMeshAgent>();
	}
	
	void Update()
	{
		MobaController();
		ZoomController();
		testController();
	}
	
	void MobaController()
	{
		if (Input.GetMouseButton(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, 1000))
			{
				agent.SetDestination(hit.point);
				//body.transform.LookAt(new Vector3(hit.point.x, 4, hit.point.z));
				
				foreach (GameObject preview in GameObject.FindGameObjectsWithTag("movePreview"))
				{
					Destroy(preview);
				}
				Instantiate(movePreview, hit.point, Quaternion.identity);
			}
		}
	}
	
	void ZoomController()
	{
		oldSize = camera.orthographicSize;
		newSize += -Input.GetAxis("Mouse ScrollWheel") * 10;
		
		camera.orthographicSize = Mathf.Lerp(oldSize, newSize, Time.deltaTime * 10f);
		
		if(camera.orthographicSize < 2)
		{
			camera.orthographicSize = 2;
			newSize = 2;
		}
		if(camera.orthographicSize > 35)
		{
			camera.orthographicSize = 35;
			newSize = 35;
		}
	}
	
	void testController()
	{
		
	}
}
