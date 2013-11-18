using UnityEngine;
using System.Collections;

public class DrewPlayer : MonoBehaviour
{
	private DrewPlayer Instance;
	private DialogueScript dialogue;
	private AnimationScript animation;
	private GameObject dialogueObject;
	public RaycastHit hit;
	public Ray ray;
	public Vector3 direction;
	public float moveSpeed = 0.1f;
	public int rotateSpeed =50;
	public Camera camera;
	public bool inMission, talking;
	public bool [] Missions;
	public Vector3 mousePoint;
	
	// Use this for initialization
	void Start () 
	{
		Instance = this;
		dialogueObject = GameObject.FindGameObjectWithTag("chatObject");
		dialogue = dialogueObject.GetComponent<DialogueScript>();
		animation = this.GetComponent<AnimationScript>();
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
		Vector3 mousePos = Input.mousePosition;
		
		if(Input.GetMouseButton(0))
		{
			rigidbody.isKinematic = false;
			
			animation.StartCoroutine_Auto(animation.updateTiling());
			if(!talking)
			{
				ray = Camera.main.ScreenPointToRay(mousePos);
				Plane playerPlane = new Plane(Vector3.forward, transform.position);
				float hitDist = 0.0f;
				
				if(Physics.Raycast (ray, out hit, 20))
				{
					direction = new Vector3(hit.point.x, hit.point.y - 0.5f, -0.6f);
					
					this.transform.position = Vector3.MoveTowards(this.transform.position, direction, moveSpeed * Time.deltaTime);
					Debug.DrawLine(this.transform.position, hit.point, Color.blue, 2);
					Vector3 targetPoint = hit.point;
					
					//player rotate code... 
					
					if (playerPlane.Raycast(ray, out hitDist))
					{
						mousePoint = ray.GetPoint(hitDist);
						Quaternion targetRotation = Quaternion.LookRotation(mousePoint - this.transform.position, Vector3.forward);
						this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, targetRotation, rotateSpeed);
						this.transform.rotation = Quaternion.Euler(0, 0, this.transform.eulerAngles.z);
					}
					//targetPoint.y = 0;
				}
			}
			animation.StopAllCoroutines();
		}
		if (Input.GetMouseButtonUp(0) || !Physics.Raycast(ray))
		{
			rigidbody.isKinematic = true;
		}
		
		if(Input.GetMouseButtonDown(1))
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast (ray, out hit,10))
			{         
				Debug.DrawLine(this.transform.position, hit.point, Color.red, 2);
				float dis = Vector3.Distance(this.transform.position, hit.transform.position);
				if(dis < 4)
				{
					
					if(hit.collider.tag == "NPC")
					{
						
						
						talking = true;
						if(inMission)
						{
							
							dialogue.autoResponse();
							
						}
						else if(hit.transform.name == "NPC1" && Missions[0] == false)
						{
							dialogue.StartDialogue("NPC1");
							Missions[0] = true;
							
						}
						
					}
					if(hit.transform.tag == "Object")
					{
						
					}
				}
			}
		}		
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
		print ("hit something");
		if(other.gameObject.tag == "JumpObjects")
		{
			print ("Hit teleporter");
			Teleport(other.transform.name);
		}
	}
}