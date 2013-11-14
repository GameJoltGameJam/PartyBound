using UnityEngine;
using System.Collections;

public class DialogueScript : MonoBehaviour 
{
	private DialogueScript Instance;
	private tempPlayerScript player;
	private GameObject playerObject;
	// Use this for initialization
	void Start () 
	{
		Instance = this;
		playerObject = GameObject.FindGameObjectWithTag("Player");
		player = playerObject.GetComponent<tempPlayerScript>();
		
	}
	public void autoResponse()
	{
	   int tempint = Random.Range(0,6);
		switch(tempint)
		{
			case 0:
			{
				
				break;	
			}
			case 1:
			{
				
				break;
			}
			case 2:
			{
				break;
			}
			case 3:
			{
				
			 	break;
			}
			case 4:
			{
				
				break;
			}
			case 5:
			{
				
				break;
			}
		}
	}
	
	public void StartDialogue(string name)
	{
	
	}
	// Update is called once per frame
	void Update () 
	{
	
	}
}
