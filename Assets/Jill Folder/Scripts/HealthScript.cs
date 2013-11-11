using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {
	
	public const int MAX_HEALTH = 100;
	public int currentHealth = 100;
	
	public int healthBarLength = 100;
	public int healthBarHeight = 25;
	
	public GUIStyle healthBarStyle;
	
	private Texture2D healthTexture;

	// Use this for initialization
	void Start () 
	{
		healthTexture = MakeTex(currentHealth, healthBarHeight, new Color(0f, 1f, 0f, 1f));
		healthBarStyle.normal.background = healthTexture;
	}
			
	private Texture2D MakeTex(int width, int height, Color color)
	{
		Color[] pixels = new Color[width * height];
		for(int i = 0; i < pixels.Length; i++)
		{
			pixels[i] = color;	
		}
		Texture2D result = new Texture2D(width, height);
		result.SetPixels(pixels);
		result.Apply();
		return result;
	}
	
	// Update is called once per frame
	void Update () 
	{		
		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			Debug.Log("Up Pressed");
			AdjustHealth(5);
		}
		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			Debug.Log("Down Pressed");
			AdjustHealth(-5);
		}
	}
	
	void OnGUI()
	{
		GUI.Box(new Rect(10, 10, currentHealth, healthBarHeight), "", healthBarStyle);
		GUI.Box(new Rect(10, 10, healthBarLength, healthBarHeight), "Popularity");
	}
	
	public void AdjustHealth(int health)
	{
		if(health > 0 && currentHealth < 100)
		{
			Debug.Log("Health Added");
			currentHealth += health;
		}
		if(health < 0 && currentHealth > 0)
		{
			Debug.Log("Health Subtracted");
			currentHealth += health;
		}
		
		// Clamp the health values
		if(currentHealth > 100)
			currentHealth = 100;
		else if(currentHealth < 0)
			currentHealth = 0;
		
		// Adjust the health bar fill meter
		if(currentHealth > 0)
		{
			healthTexture = MakeTex(currentHealth, healthBarHeight, new Color(0f, 1f, 0f, 1f));
			healthBarStyle.normal.background = healthTexture;
		}
		else
			healthBarStyle.normal.background = null;
		
	}
}
