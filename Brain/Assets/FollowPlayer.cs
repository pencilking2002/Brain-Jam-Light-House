using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowPlayer : MonoBehaviour {
	
	private Transform player;
	private PlayerController3 pController;
	
	public float speed = 10.0f;
	
	private Vector3 vel;
	private Vector3 rotVel;
		
	private bool canActivateLightHouse = false;
	private LightTrigger currentLightTrigger = null;
	
	[HideInInspector]
	public enum LightingState
	{
		Normal,
		CanEnableLightHouse,
		EnablingLightHouse
	}
	
	[HideInInspector]
	public LightingState state = LightingState.Normal;
	 
	//private List<LightTrigger> lightTriggers = new List<LightTrigger>();
	private LightTrigger[] lightTriggers;
	
	
	private void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		lightTriggers = GameObject.FindObjectsOfType<LightTrigger>();
		print ("light trigger count" + lightTriggers.Length);
		
		pController = player.GetComponent<PlayerController3>();
	}
	
	public void LightAll()
	{
		foreach(LightTrigger lt in lightTriggers)
		{
			lt.EnableLight();
		}
	}
	
	private void Update ()
	{
		transform.position = Vector3.SmoothDamp (transform.position, player.position, ref vel, speed * Time.deltaTime);
		transform.localEulerAngles = Vector3.SmoothDamp(transform.localEulerAngles, new Vector3 (player.localEulerAngles.x, player.localEulerAngles.y, 0) , ref rotVel, speed * Time.deltaTime);
		
		//transform.rotation = Quaternion.LookRotation(player.forward);
		
		if (Input.GetKeyDown (KeyCode.Space))
		{
			if (currentLightTrigger != null && !IsEnabling() && CanEnable())
			{
				currentLightTrigger.EnableLight();	
				SetState(LightingState.EnablingLightHouse);		
			}
		}
	}
	
	private void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.layer == 15)
		{
			SetState(LightingState.CanEnableLightHouse);
			
			currentLightTrigger = col.GetComponent<LightTrigger>();
			
			pController.ScalePlayer(true);
//			print ("follow enter");
//			col.GetComponent<LightTrigger>().EnableLight();
		}
	}
	
	private void OnTriggerExit (Collider col)
	{
		canActivateLightHouse = false;
		SetState(LightingState.Normal);
		pController.ScalePlayer(false);
		
	}
	
	private void SetState (LightingState _state)
	{
		state = _state;			
	}
	
	public LightingState GetState ()
	{
		return state;	
	}
	
	private bool IsEnabling ()
	{
		return state == LightingState.EnablingLightHouse;
	}
	
	private bool CanEnable ()
	{
		return state == LightingState.CanEnableLightHouse;
	}
}
