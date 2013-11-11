using UnityEngine;
using System.Collections;

public class playerScript : MonoBehaviour 
{
	public RaycastHit hit;
    public Ray ray;
    public Vector3 direction;
    public float moveSpeed = 0.1f;
    public int rotateSpeed =50;
 	public Camera camera;
	
	// Use this for initialization
	void Start () 
	{
		direction = this.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		#region MouseControl
		if(Input.GetMouseButton(0))
        {
         ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         if(Physics.Raycast (ray, out hit, 100))
         {         
             
              direction = new Vector3(hit.point.x, hit.point.y, -0.6f);	 
             this.transform.position = Vector3.MoveTowards(this.transform.position, hit.point, moveSpeed * Time.deltaTime);
              Debug.DrawLine(this.transform.position, hit.point, Color.blue, 2);
 
              Vector3 targetPoint = hit.point;
                 Quaternion targetRotation = Quaternion.LookRotation(targetPoint - this.transform.position);
                 this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
          targetPoint.y = 0;
          }
 			this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -0.6f);
 			this.transform.rotation = new Quaternion(this.transform.rotation.x, 0,0,0);
         }
		#endregion
		if (Physics.Raycast (ray, out hit, 10)) 
		{
			
		}
		#region Collision
		//check if raycast touches the barrier
		#endregion
	}
}