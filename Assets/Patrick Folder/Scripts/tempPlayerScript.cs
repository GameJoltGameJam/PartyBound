using UnityEngine;
using System.Collections;

public class tempPlayerScript : MonoBehaviour
{
	private tempPlayerScript Instance;
	private DialogueScript dialogue;
	private GameObject dialogueObject;
   	public RaycastHit hit;
    public Ray ray;
    public Vector3 direction;
    public float moveSpeed = 0.1f;
    public int rotateSpeed =50;
 	public Camera camera;
 	public bool inMission, talking;
	public bool [] Missions;
    // Use this for initialization
    void Start () 
    {
		Instance = this;
		dialogueObject = GameObject.FindGameObjectWithTag("chatObject");
		dialogue = dialogueObject.GetComponent<DialogueScript>();
		direction = this.transform.position;
		inMission = talking = false;
		Missions = new bool [10];
	    for (int i= 0; i < 9; i++) 
		{
	    	Missions[i] = false;
			
	    }
    }
 
    // Update is called once per frame
    void FixedUpdate () 
    {  
		if(!talking)
		{
	   	if(Input.GetMouseButton(0))
   	   	{
        	ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        	if(Physics.Raycast (ray, out hit, 20))
         	{         
            	direction = new Vector3(hit.point.x, hit.point.y, -0.6f);	 
            	this.transform.position = Vector3.MoveTowards(this.transform.position, hit.point, moveSpeed * Time.deltaTime);
              	Debug.DrawLine(this.transform.position, hit.point, Color.blue, 2);
 	            Vector3 targetPoint = hit.point;
                Quaternion targetRotation = Quaternion.LookRotation(targetPoint - this.transform.position);
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
    		    targetPoint.y = 0;
         	}
      	}
		}
		if(Input.GetMouseButtonDown(1))
    	{
    		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       		if(Physics.Raycast (ray, out hit,10))
       		{         
 				Debug.DrawLine(this.transform.position, hit.point, Color.red, 2);
				float dis = Vector3.Distance(this.transform.position, hit.transform.position);
				if(dis < 3)
				{
					if(hit.transform.tag == "NPC")
					{
						talking = true;
						if(inMission)
						{
							dialogue.autoResponse();
						}
						if(hit.transform.name == "NPC1" && Missions[0] == false)
						{
							dialogue.StartDialogue("NPC1");
							Missions[0] = true;
							
						}
						talking = false;
					}
					if(hit.transform.tag == "Object")
					{
						
					}
				}
		 	}
		}
		if(!talking)
		{
		this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -0.6f);
		this.transform.rotation = new Quaternion(0, 0,this.transform.rotation.z ,0);
		}
 	}
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name == "4WayPortal1")
		{
			this.transform.position = new Vector3(0.0f,-27.0f,-0.6f);
			camera.enabled = false;
			camera.transform.position = new Vector3(0.0f, -40.0f,-10.0f);
			camera.enabled = true;
			
		}
		else if(other.gameObject.name == "4WayPortal3")
		{
			this.transform.position = new Vector3(0.0f,-53.0f,-0.6f);
			camera.enabled = false;
			camera.transform.position = new Vector3(0.0f, -40.0f,-10.0f);
			camera.enabled = true;
			
		}
		else if(other.gameObject.name == "4WayPortal4")
		{
			this.transform.position = new Vector3(-14.0f,-40.0f,-0.6f);
			camera.enabled = false;
			camera.transform.position = new Vector3(0.0f, -40.0f,-10.0f);
			camera.transform.Rotate(0.0f,0.0f,270.0f);
			camera.enabled = true;
			
		}
		else if(other.gameObject.name == "PhPortal")
		{ 
			this.transform.position = new Vector3(0.0f, -13.0f, -0.6f);
			camera.enabled = false;
			camera.transform.position = new Vector3 (0.0f,0.0f,-10.0f);
			camera.enabled = true;
		}
		else if(other.gameObject.name == "FhPortal")
		{ 
			this.transform.position = new Vector3(-26.0f, -37.0f, -0.6f);
			camera.enabled = false;
			camera.transform.position = new Vector3 (-40.0f,-40.0f,-10.0f);
			camera.transform.Rotate(0.0f,0.0f,90.0f);
			camera.enabled = true;
		}
		
		else if(other.gameObject.name == "BigPortal")
		{ 
			this.transform.position = new Vector3(-4.0f, -67.0f, -0.6f);
			camera.enabled = false;
			camera.transform.position = new Vector3 (0.0f,-80.0f,-10.0f);
			camera.enabled = true;
		}
	
	}
}