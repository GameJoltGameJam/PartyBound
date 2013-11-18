using UnityEngine;
using System.Collections;

public class ObjectScript : MonoBehaviour {
	public static ObjectScript Instance;

	public struct Objects
	{

		bool  active;
		Vector3 position;
		GameObject contents;

	}
	public Objects [] objects;

	// Use this for initialization
	void Start () 
	{
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
