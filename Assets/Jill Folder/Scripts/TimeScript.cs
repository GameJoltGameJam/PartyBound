using UnityEngine;
using System.Collections;

public class TimeScript : MonoBehaviour {
	
	public int startTime = 0;
	public int endTime = 43200;
	public float currentTime = 0;
	
	public int timeBarWidth = 300;
	public int timeBarHeight = 25;
	
	public int hour;
	public int minute;
	
	private string minutesToString;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		currentTime += (Time.deltaTime * 24);
		
		// Calculate what the hour and the minute is
		minute = (int)(currentTime / 60) % 60;
		hour = (int)(currentTime / 3600) + 9;
		
		if(hour > 12)
		{
			hour -= 12;	
		}
		
		if(minute < 10)
		{
			minutesToString = "0" + minute.ToString("0");	
		}
		else
		{
			minutesToString = minute.ToString("0");	
		}
	}
	
	void OnGUI()
	{
		GUI.Box(new Rect((Screen.width / 2) - (timeBarWidth / 2), 10, timeBarWidth, timeBarHeight), "Time: " + hour + ": " + minutesToString);	
	}
}
