using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	public float distAway = 2.0f;
	
	private Transform player;
	private Transform follow;
	private Vector3 targetPos;
	private Vector3 vel;

	
	private void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		follow = GameObject.FindGameObjectWithTag("Follow").transform;
	}
	
	private void LateUpdate ()
	{
		//targetPos = Vector3.SmoothDamp (transform.position, follow.position + follow.up * distAway, ref vel, 10.0f * Time.deltaTime);
		targetPos = follow.position + follow.forward * -distAway;
		
		transform.position = targetPos;
		
		//transform.LookAt(Vector3.zero);
		transform.rotation = Quaternion.LookRotation(follow.forward);
		transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, follow.localEulerAngles.z + 180);
	}
}
