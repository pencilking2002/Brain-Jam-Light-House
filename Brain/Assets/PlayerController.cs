using UnityEngine;
using System.Collections;

using UnityEngine;  
using System.Collections;  

[RequireComponent (typeof (CharacterController))]  
public class PlayerController : MonoBehaviour   
{  
	private Camera cam;
	
	//this game object's Transform  
	private Transform goTransform;  
	
	private Vector3 forward;
	private Vector3 right;
	
	//the speed to move the game object  
	public float speed = 6.0f;  
	//the gravity  
	public float gravity = 50.0f;  
	
	//the direction to move the character  
	private Vector3 moveDirection = Vector3.zero;  
	//the attached character controller  
	private CharacterController cController;  
	
	//a ray to be cast   
	private Ray ray;  
	//A class that stores ray collision info  
	private RaycastHit hit;  
	
	//a class to store the previous normal value  
	private Vector3 oldNormal;  
	//the threshold, to discard some of the normal value variations  
	public float threshold = 0.009f;  
	
	private float h,v;
	
	private Vector3 vel;
	
	// Use this for initialization  
	void Start ()   
	{  
		//get this game object's Transform  
		goTransform = this.GetComponent<Transform>();  
		//get the attached CharacterController component  
		cController = GetComponent<CharacterController>();  
		
		cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		
	}  
	
	// Update is called once per frame  
	void Update ()   
	{  
		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Veritcal");
		
		//cast a ray from the current game object position downward, relative to the current game object orientation  
		ray = new Ray(goTransform.position, -goTransform.up);    
		
		//if the ray has hit something  
//		if(Physics.Raycast(ray.origin,ray.direction, out hit, 5))//cast the ray 5 units at the specified direction    
//		{    
//			//if the current goTransform.up.y value has passed the threshold test  
//			if(oldNormal.y >= goTransform.up.y + threshold || oldNormal.y <= goTransform.up.y - threshold)  
//			{  
//				//set the up vector to match the normal of the ray's collision  
//				goTransform.up = hit.normal;  
//			}  
//			//store the current hit.normal inside the oldNormal  
//			oldNormal =  hit.normal;  
//		}

    	goTransform.up = -(Vector3.zero - transform.position).normalized;  
		
		//move the game object based on keyboard input  
		moveDirection = new Vector3(h, 0, -v);
		
		print (moveDirection);
		
		if (moveDirection != Vector3.zero)
		{  
			
			//apply the movement relative to the attached game object orientation  
			moveDirection = goTransform.TransformDirection(moveDirection);   
			moveDirection = Camera.main.transform.TransformDirection(moveDirection);
			moveDirection.y = 0;
			
			//moveDirection = Camera.main.transform.TransformDirection(moveDirection);
			//moveDirection = Vector3.Scale(moveDirection, cam.transform.localEulerAngles);
			//moveDirection = moveDirection.normalized;
			
			//apply the speed to move the game object  
			moveDirection *= speed;  
		}
		
		// Apply gravity down, relative to the containing game object orientation  
		moveDirection.y -= gravity * Time.deltaTime * goTransform.up.y;  
		
		
//		
//		forward = cam.transform.TransformDirection(Vector3.forward);
//		forward.y = 0;
//		forward = forward.normalized;
//		right = new Vector3(right.x, 0, -forward.z);
		
		//moveDirection = new Vector3 (moveDirection.x, moveDirection.y, moveDirection.z).normalized;
		if (h != 0 && v != 0)
			cController.Move(moveDirection * Time.deltaTime);


	}  
}  
