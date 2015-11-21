using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	
	private Transform player;
	public float speed = 10.0f;
	
	private Vector3 vel;
		
	private void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	private void Update ()
	{
		transform.position = Vector3.SmoothDamp (transform.position, player.position, ref vel, speed);
		transform.LookAt(Vector3.zero);	
	}
}
