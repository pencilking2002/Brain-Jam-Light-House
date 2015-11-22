using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterController))]  
public class PlayerController3 : MonoBehaviour   
{  
	// the speed to move the game object
	public float speed = 6.0f;
	
	// Gravity pulling the player into the climb collider
	public float gravity = 50.0f;
	
	// The threshold, to discard some of the normal value variations
	public float threshold = 0.009f;
	
	public float raycastLength = 4.0f;
	
	private RaycastHit hit;
	private Vector3 oldNormal;
	private Vector3 moveDirection;
	private CharacterController cController;
	private Camera cam;
	private int layerMask = 1 << 8;
	private int layerMaskLand = 1 << 9;
	private float h,v;
	
	[HideInInspector] public bool atSurface = false;					// Is the ball as close as possible to planet surface?
	[HideInInspector] public bool onWater = false;					// Is the ball as close as possible to planet surface?
	
	
	private Vector3 origin = new Vector3 (0.1f, 0.1f, 0.1f);
	
	private void Start ()
	{
		cController = GetComponent<CharacterController>(); 
		cam = Camera.main; 
		atSurface = false;
	}
	
	private void Update ()
	{
		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");
		
		Debug.DrawRay(transform.position, (origin - transform.position).normalized * raycastLength, Color.red);
		
		if (Physics.Raycast(transform.position, transform.forward, raycastLength, layerMask))
		{
			atSurface = true;
		}
		else
		{
			atSurface = false;
		}
		
//		if (Physics.Raycast(transform.position, transform.forward, raycastLength + 2.0f, layerMaskLand))
//		{
//			onWater = false;
//			
//		}
//		else
//		{
//			onWater = true;
//		}
		
		//if the ray has hit something
		if(Physics.Raycast(transform.position, transform.forward, out hit, 2f))//cast the ray 5 units at the specified direction  
		{  
			
			//if the current goTransform.up.y value has passed the threshold test
			if(oldNormal.z >= transform.forward.z + threshold || oldNormal.z <= transform.forward.z - threshold)
			{
				//smoothly match the player's forward with the inverse of the normal
				transform.forward = Vector3.Lerp (transform.forward, -hit.normal, 10 * Time.deltaTime);
			}
			//store the current hit.normal inside the oldNormal
			oldNormal = -hit.normal;	
		}

		//transform.forward = (origin- transform.position).normalized;
		
		//transform.localEulerAngles = new Vector3 (transform.localEulerAngles.x, transform.localEulerAngles.y, 0);
					
		moveDirection = new Vector3(h * speed, v * speed, 0)  * Time.deltaTime; 
		
		moveDirection = transform.TransformDirection(moveDirection);
		
		if (!atSurface)
			moveDirection.z -= gravity * transform.forward.z * Time.deltaTime;
		
		//if (onWater)
			cController.Move(moveDirection);
		
	}
	
//	private void OnCollisionStay ()
//	{
//		atSurface = true;
//	}
//	
////	private void OnCollisionEnter ()
////	{
////		//print ("enter");
////		atSurface = true;
////	}
////	
//	private void OnCollisionExit ()
//	{
//		//print ("enter");
//		atSurface = false;
//	}

}  