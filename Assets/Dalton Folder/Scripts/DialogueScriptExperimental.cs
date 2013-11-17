using UnityEngine;
using System.Collections;

public class DialogueScript : MonoBehaviour 
{
	private DialogueScript Instance;
	private tempPlayerScript player;
	private GameObject playerObject;
    private bool bYesNo;
	// Use this for initialization
	void Start () 
	{
		Instance = this;
		playerObject = GameObject.FindGameObjectWithTag("Player");
		player = playerObject.GetComponent<tempPlayerScript>();
        bYesNo = true;
		
	}
	public void autoResponse()
	{
	   int tempint = Random.Range(0,6);
		switch(tempint)
		{
			case 0:
			{
                Gui("Lemme know when you're done.");//Auto responses
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
	
	public int StartDialogue(string name, bool [] missions)//Returns Mission Number
	{
        bool tempbool;
        for (int i = 0; i++; i < 10)
            if(missions[i])
                tempbool = true;//Checks if any of the missions are in progress

        switch (name)
        {
            case "NPC1":
                {
                    if (tempbool)//Auto response if any mission in progress
                    {
                        autoResponse();
                    }
                    else
                    {
                        Gui("Quest Text");//etc etc
                        return 1; //Return the proper quest number
                    }
                    break;
                }
            case "NPC2":
                {
                    if (tempbool && !missions[2])//Auto Response for missions
                    {                           //If not a part of the mission
                        autoResponse();
                    }
                    else if (missions[2])
                    {
                        Gui("Quest Help Text");//For NPC if they help in another quest
                    }
                    else
                    {
                        Gui("Quest start text");//Starts Quest Text
                        return 3; //Return the proper quest number
                    }

                    break;
                }
            case "NPC3":
                {
                    if (tempbool && !missions[3])//Auto Response for missions
                    {                           //If not a part of the mission
                        autoResponse();
                    }
                    else if (missions[3])
                    {
                        Gui("Quest End Text");//For NPC if they help in another quest
                        return 3; //Return the int of the quest being finished
                    }
                    break;
                }
            case "NPC4":
                {

                    break;
                }
            case "NPC5":
                {

                    break;
                }
            case "NPC6":
                {

                    break;
                }
        }
        return null;
	}
	// Update is called once per frame
	public bool Update () 
	{
        return ScrollWheelInput();        
	}
    void Gui(string text)
    {
        GUI.Box(new Rect(0, Screen.height - (Screen.height / 3), Screen.width, Screen.height / 3),
            text);// \n to get to next line for proper spacing
    }
    bool GuiOptions() //Yess or no for missions
    {
        if (bYesNo)//If true then Yes is highlighted
        {
            GUI.Box(new Rect(Screen.width - (Screen.width / 8), Screen.height - (Screen.height * 3 / 6), Screen.width / 8, Screen.height / 15), "No");
            GUI.Box(new Rect(Screen.width - (Screen.width / 6), Screen.height - (Screen.height * 3 / 7), Screen.width / 6, Screen.height / 15), "Yes");
            return true;
        }
        else if(!bYesNo) //If no then false is hightlighted
        {
            GUI.Box(new Rect(Screen.width - (Screen.width / 6), Screen.height - (Screen.height * 3 / 6), Screen.width / 6, Screen.height / 15), "No");
            GUI.Box(new Rect(Screen.width - (Screen.width / 8), Screen.height - (Screen.height * 3 / 7), Screen.width / 8, Screen.height / 15), "Yes");
            return false;
        }
        return false;
    }
    bool ScrollWheelInput()
    {
        if(Input.GetButtonDown("[Y]")) //Y and N keys for placeholders, not sure what key is prefered
            bYesNo = true;
        else if(Input.GetButtonDown("[N]"))
            bYesNo = false;
        if(Input.GetMouseButtonDown(0))//Clicks, changing update to TRUE and picking the GuiOption
            return true;
        
        return false;
    }
}
