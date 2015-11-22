using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	
	private Transform player;
	public float speed = 10.0f;
	
	private Vector3 vel;
	private Vector3 rotVel;
		
	private void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	private void Update ()
	{
		transform.position = Vector3.SmoothDamp (transform.position, player.position, ref vel, speed * Time.deltaTime);
		transform.localEulerAngles = Vector3.SmoothDamp(transform.localEulerAngles, new Vector3 (player.localEulerAngles.x, player.localEulerAngles.y, 0) , ref rotVel, speed * Time.deltaTime);
		
		//transform.rotation = Quaternion.LookRotation(player.forward);
	}
}
