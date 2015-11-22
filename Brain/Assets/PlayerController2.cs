using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterController))]  
public class PlayerController2 : MonoBehaviour   
{  
	private CharacterController cController;
	private Vector3 moveDirection = Vector3.zero;
	public float speed = 5.0f;
	public float gravity = -50.0f;
	
	
	Vector3 surfaceNormal;//The normal of the surface the ray hit.
	Vector3 forwardRelativeToSurfaceNormal;//For Look Rotation
	//- See more at: http://www.theappguruz.com/blog/character-rotation-movement-according-surface-unity#sthash.hsag2Toe.dpuf
	
	private Camera cam;
	private RaycastHit hit;
	
	private Vector3 oldNormal;
	
	private void Start ()
	{
		cController = GetComponent<CharacterController>();
		cam = Camera.main;
	}

	private void Update ()
	{	
//		// Rotation
//		//For Detect The Base/Surface.
//		
//		//Debug.DrawRay(transform.position, -Vector3.up * 10, Color.red);
//		
//		if (Physics.Raycast(transform.position, -transform.up, out hit, 10))
//		{
//			surfaceNormal = hit.normal; // Assign the normal of the surface to surfaceNormal
//			forwardRelativeToSurfaceNormal = Vector3.Cross(transform.right, surfaceNormal);
//			Quaternion targetRotation = Quaternion.LookRotation(forwardRelativeToSurfaceNormal, surfaceNormal); //check For target Rotation.
//			transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 2); //Rotate Character accordingly.
//		}
//		//- See more at: http://www.theappguruz.com/blog/character-rotation-movement-according-surface-unity#sthash.hsag2Toe.dpuf
//		
//		
//		
//		
//		moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); // Get Input From User
//		
//		moveDirection.y -= gravity * Time.deltaTime; //Move Character Down Because Of Gravity That We have assign before.
//		moveDirection = transform.TransformDirection(moveDirection);//Specify The Character Movement Direction in world space.
//		
//		moveDirection *= speed;//Add Movement Speed To Character.
//
//		
//		cController.Move(moveDirection * Time.deltaTime);//Move The Character in specific Direction.
//		//- See more at: http://www.theappguruz.com/blog/character-rotation-movement-according-surface-unity#sthash.hsag2Toe.dpuf

		Debug.DrawRay(transform.position, transform.forward * 2f, Color.red);
		
		//if the ray has hit something
		if(Physics.Raycast(transform.position, transform.forward, out hit, 2f))//cast the ray 5 units at the specified direction  
		{  
			
			//smoothly match the player's forward with the inverse of the normal
			transform.forward = Vector3.Lerp (transform.forward, -hit.normal, 10 * Time.deltaTime);
			//transform.forward = -hit.normal;
			//store the current hit.normal inside the oldNormal
			//oldNormal = -hit.normal;	
		} 
		
		
		//moveDirection = new Vector3(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed, 0)  * Time.deltaTime; 
		
		moveDirection = Input.GetAxis("Vertical")* cam.transform.forward + Input.GetAxis("Horizontal") * cam.transform.right;
		//tempTarget.y = 0f;
		
		if (moveDirection != Vector3.zero)
			moveDirection.z += gravity * Time.deltaTime;
			
		moveDirection = transform.TransformDirection(moveDirection);
		
		
		
		

		cController.Move(moveDirection);

		
	}
}  