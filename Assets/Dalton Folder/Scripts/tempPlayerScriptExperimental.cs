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
		//dialogue = dialogueObject.GetComponent<DialogueScript>();
		direction = this.transform.position;
		camera.transform.position = new Vector3(0,80,-10);
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
		
	   	if(Input.GetMouseButton(0))
   	   	{
        	ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        	if(Physics.Raycast (ray, out hit, 20))
         	{         
            	direction = new Vector3(hit.point.x, hit.point.y, -0.6f);	 
            	this.transform.position = Vector3.MoveTowards(this.transform.position, hit.point, moveSpeed * Time.deltaTime);
              	Debug.DrawLine(this.transform.position, hit.point, Color.blue, 2);
 	            Vector3 targetPoint = hit.point;
					//player rotate code... 
                Quaternion targetRotation = Quaternion.LookRotation(targetPoint - this.transform.position);
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
    		    targetPoint.y = 0;
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
                        //if(inMission)
                        //{
                        //    dialogue.autoResponse();
                        //}
                        //if(hit.transform.name == "NPC1" && Missions[0] == false)
                        //{
                        //    dialogue.StartDialogue("NPC1");
                        //    Missions[0] = true;
							
                        //}
                        int iTempInt = NULL;
                        bool TemporaryBool = true;
                        
                        //Automatically 'should' check missions/npc automatically
                        
                        while (!dialogue.Update())//Not 100% sure if while loop is appropriate here
                        {                           //This loop lasts untill something is clicked
                            iTempInt = dialogue.StartDialogue(hit.transform.name, Missions);//Temp int is the Mission Number to be Accepted
                            if( iTempInt != NULL)
                            {  
                                if(Mission[iTempInt])//if Start dialogue returned a value of a mission in progress, taht means its completed, so set it to false
                                    Mission[iTempInt] = false;
                                else TemporaryBool = dialogue.GuiOptions();
                        }
                        if (TemporaryBool == true && iTempInt != NULL)
                            Missions[iTempInt] = true;//On completion of a mission this the missions need to be scrubbed to false
						talking = false;
					}
					if(hit.transform.tag == "Object")
					{
						
					}
				}
		 	}
		}
	
		this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -0.6f);
		this.transform.rotation = new Quaternion(0, 0,this.transform.rotation.z ,0);
		
 	}
	void Teleport(string name)
	{
		switch(name)
		{
		case "1":
		{
			this.transform.position = new Vector3(0,51,-0.6f);
			camera.enabled = false;
			camera.transform.position = new Vector3(0,40,-10);
			camera.enabled = true;
			break;
		}
		case "2":
		{
			this.transform.position = new Vector3(3,67,-0.6f);
			camera.enabled = false;
			camera.transform.position = new Vector3(0,80,-10);
			camera.enabled = true;
			break;
		}
		case "3":
		{
			this.transform.position = new Vector3(0,12,-0.6f);
			camera.enabled = false;
			camera.transform.position = new Vector3(0,0,-10);
			camera.enabled = true;
			break;
		}
		case "4":
		{
			this.transform.position = new Vector3(0,26,-0.6f);
			camera.enabled = false;
			camera.transform.position = new Vector3(0,40,-10);
			camera.enabled = true;
			break;
		}
		case "5":
		{
			this.transform.position = new Vector3(0,-27,-0.6f);
			camera.enabled = false;
			camera.transform.position = new Vector3(0,-40,-10);
			camera.enabled = true;
			break;
		}
		case "6":
		{
			this.transform.position = new Vector3(-27,0,-0.6f);
			camera.enabled = false;
			camera.transform.position = new Vector3(-40,0,-10);
			camera.enabled = true;
			break;
		}
		case "7":
		{
			this.transform.position = new Vector3(27,0,-0.6f);
			camera.enabled = false;
			camera.transform.position = new Vector3(40,0,-10);
			camera.enabled = true;
			break;
		}
		case "8":
		{
			this.transform.position = new Vector3(0,-12,-0.6f);
			camera.enabled = false;
			camera.transform.position = new Vector3(0,0,-10);
			camera.enabled = true;
			break;
		}
		case "9":
		{
			this.transform.position = new Vector3(-13,0,-0.6f);
			camera.enabled = false;
			camera.transform.position = new Vector3(0,0,-10);
			camera.enabled = true;
			break;
		}
		case "10":
		{
			this.transform.position = new Vector3(-67,3,-0.6f);
			camera.enabled = false;
			camera.transform.position = new Vector3(-80,0,-10);
			camera.enabled = true;
			break;
		}
		case "11":
		{
			this.transform.position = new Vector3(-53,0,-0.6f);
			camera.enabled = false;
			camera.transform.position = new Vector3(-40,0,-10);
			camera.enabled = true;
			break;
		}
		case "12":
		{
			this.transform.position = new Vector3(12,0,-0.6f);
			camera.enabled = false;
			camera.transform.position = new Vector3(0,0,-10);
			camera.enabled = true;
			break;
		}
		case "13":
		{
			this.transform.position = new Vector3(68.5f,0,-0.6f);
			camera.enabled = false;
			camera.transform.position = new Vector3(80,0,-10);
			camera.enabled = true;
			break;
		}
		case "14":
		{
			this.transform.position = new Vector3(53,7,-0.6f);
			camera.enabled = false;
			camera.transform.position = new Vector3(40,0,-10);
			camera.enabled = true;
			break;
		}	
		case "15":
		{
			this.transform.position = new Vector3(107,0,-0.6f);
			camera.enabled = false;
			camera.transform.position = new Vector3(120,0,-10);
			camera.enabled = true;
			break;
		}
		case "16":
		{
			this.transform.position = new Vector3(93,0,-0.6f);
			camera.enabled = false;
			camera.transform.position = new Vector3(80,0,-10);
			camera.enabled = true;
			break;
		}
		case "17":
		{
			this.transform.position = new Vector3(80,27,-0.6f);
			camera.enabled = false;
			camera.transform.position = new Vector3(80,40,-10);
			camera.enabled = true;
			break;
		}
		case "18":
		{
			this.transform.position = new Vector3(80,13,-0.6f);
			camera.enabled = false;
			camera.transform.position = new Vector3(80,0,-10);
			camera.enabled = true;
			break;
		}
		case "19":
		{
			this.transform.position = new Vector3(83,67,-0.6f);
			camera.enabled = false;
			camera.transform.position = new Vector3(80,80,-10);
			camera.enabled = true;
			break;
		}
		case "20":
		{
			this.transform.position = new Vector3(80,52,-0.6f);
			camera.enabled = false;
			camera.transform.position = new Vector3(80,40,-10);
			camera.enabled = true;
			break;
		}
		case "21":
		{
			this.transform.position = new Vector3(78,-27,-0.6f);
			camera.enabled = false;
			camera.transform.position = new Vector3(80,-40,-10);
			camera.enabled = true;
			break;
		}
		case "22":
		{
			this.transform.position = new Vector3(80,-13,-0.6f);
			camera.enabled = false;
			camera.transform.position = new Vector3(80,0,-10);
			camera.enabled = true;
			break;
		}
		case "23":
		{
			this.transform.position = new Vector3(4,-67,-0.6f);
			camera.enabled = false;
			camera.transform.position = new Vector3(0,-80,-10);
			camera.enabled = true;
			break;
		}
		case "24":
		{
			this.transform.position = new Vector3(0,-53,-0.6f);
			camera.enabled = false;
			camera.transform.position = new Vector3(0,-40,-10);
			camera.enabled = true;
			break;
		}	
		case "25":
		{
			this.transform.position = new Vector3(67,40,-0.6f);
			camera.enabled = false;
			camera.transform.position = new Vector3(80,40,-10);
			camera.enabled = true;
			break;
		}	
		case "26":
		{
			this.transform.position = new Vector3(13,40,-0.6f);
			camera.enabled = false;
			camera.transform.position = new Vector3(0,40,-10);
			camera.enabled = true;
			break;
		}		
		}
			
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "JumpObjects")
		{
			Teleport(other.transform.name);
		}
	}
}