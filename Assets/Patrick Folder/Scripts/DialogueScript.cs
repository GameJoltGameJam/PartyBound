using UnityEngine;
using System.Collections;

public class DialogueScript : MonoBehaviour 
{
	private DialogueScript Instance;
	private tempPlayerScript player;
	private GameObject playerObject;
	public string mes;
	public float start, end, current;
	// Use this for initialization
	void Start () 
	{
		Instance = this;
		playerObject = GameObject.FindGameObjectWithTag("Player");
		player = playerObject.GetComponent<tempPlayerScript>();
		start = end = current = 0;
	}
	public void autoResponse()
	{
		if (current > end)
		{
	   int tempint = Random.Range(0,6);
		switch(tempint)
		{
			case 0:
			{
				 mes = "Hey, I'm busy talk to me later.";
		
				break;	
			}
			case 1:
			{
				 mes = "Im trying to find something come back later";
				
				break;
			}
			case 2:
			{
				 mes = ".....";
				
				break;
			}
			case 3:
			{
				 mes = "You sure do have alot to do, come back and talk to me.";
				
			 	break;
			}
			case 4:
			{
				 mes = "I wonder if this could work.";
				
				break;
			}
			case 5:
			{
				 mes = "Ummm. Stop talking to me your scaring me.";
				
				break;
			}
		}

		start = Time.deltaTime;
		end = start + 5.0f;
		current = 0;
		}
	}
	
	public void StartDialogue(string name)
	{
	
	}
	public void OnGUI()
	{
		current += Time.deltaTime;

		if(current < end)
		{
			GUI.Box(new Rect(0, Screen.height - (Screen.height / 4), Screen.width-(Screen.width/2), Screen.height - (Screen.height / 2)),
            mes);// \n to get to next line for proper spacing
		}
		else
		{
			player.talking = false;
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
