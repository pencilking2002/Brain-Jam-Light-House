using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	public float distAway = 2.0f;
	public float damping = 10.0f;
	
	private Transform player;
	//private Transform follow;
	private Vector3 targetPos;
	private Vector3 targetRot;
	private Vector3 vel;
	private Vector3 rotVel;
	private float xVel, yVel, zVel;
	
	
	private void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		//follow = GameObject.FindGameObjectWithTag("Follow").transform;
	}
	
	private void LateUpdate ()
	{
		// Smooth Damp the position 
		targetPos = Vector3.SmoothDamp (transform.position, player.position + player.forward * -distAway, ref vel, damping * Time.deltaTime);
		
		// Smooth Damp the camera's rotation. Use SmoothDampAngle to prevent the camera from rotating wildly because of angle changes 
		targetRot.x = Mathf.SmoothDampAngle(transform.eulerAngles.x, player.eulerAngles.x, ref xVel, damping * Time.deltaTime);
		targetRot.y = Mathf.SmoothDampAngle(transform.eulerAngles.y, player.eulerAngles.y, ref yVel, damping * Time.deltaTime);
		targetRot.z = Mathf.SmoothDampAngle(transform.eulerAngles.z, player.eulerAngles.z, ref zVel, damping * Time.deltaTime);
				
		transform.position = targetPos;
		transform.eulerAngles = targetRot;
	
	}
}
