using UnityEngine;
using System.Collections;

public class Npc1Script : MonoBehaviour
{
	public static Npc1Script Instance;
	private GameObject dialogueO;
	private DialogueScript dialogue;
	private tempPlayerScript player;
	private GameObject playerO;
	public bool getMission, onMission, endMission;



	// Use this for initialization
	void Start () 
	{
		Instance = this;
		dialogueO = GameObject.FindGameObjectWithTag("chatObject");
		dialogue = dialogueO.GetComponent<DialogueScript>();
		playerO = GameObject.FindGameObjectWithTag("Player");
		player = playerO.GetComponent<tempPlayerScript>();
		onMission = true;
		endMission = true;
		getMission = false;
	}
	
	// Update is called once per frame
	void Update () 
	{

		
	}
	public void GetMission()
	{
		print("in get");
		if(!getMission)
		{
				print ("in message");
				dialogue.mes = " Sure I will come to a party. I was hoping to fall into something tonight";
				dialogue.start = Time.deltaTime;
				dialogue.end = dialogue.start + 5.0f;
				dialogue.current = 0;
				getMission = true;
				player.talking = false;
		}
		if(getMission && onMission && endMission)
		{
			player.Missions[0] = true;
		}
	}
}
