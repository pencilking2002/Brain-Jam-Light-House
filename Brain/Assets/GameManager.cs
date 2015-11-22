using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	private PlayerController3 playerController;
	
	[HideInInspector]
	public GameObject player;
	
	[HideInInspector]
	public SphereCollider playerCollider;
	
	[HideInInspector]
	public SphereCollider followCollider;
	
	[HideInInspector]
	public GameObject follow;
	
	[HideInInspector]
	public FollowPlayer followPlayer;
	
	public bool debug = false;
	
	
	public static GameManager Instance;
	
	private void Awake ()
	{
		if (Instance == null)
			Instance = this;
		else
			Destroy (this);
			
		player = GameObject.FindGameObjectWithTag("Player");
		
		if (GameObject.FindGameObjectWithTag("Follow") != null)
			follow = GameObject.FindGameObjectWithTag("Follow");
		
		playerCollider = player.GetComponent<SphereCollider>();
		
		if (follow != null)
		{
			followCollider = follow.GetComponent<SphereCollider>();
			followPlayer = follow.GetComponent<FollowPlayer>();
		}
		
		
	}
	
	// Use this for initialization
	void Start () 
	{
		playerController = FindObjectOfType<PlayerController3>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	private void OnGUI ()
	{
		if (debug)
		{
			GUI.Button(new Rect(0, 0, 150, 20), "At surface: " + playerController.atSurface);
			
			GUI.Button(new Rect(0, 40, 150, 20), "follow light state: " + followPlayer.GetState());
			if (GUI.Button(new Rect(0, 100, 150, 20), "Turn on Lights "))
			{
				followPlayer.LightAll();
			}
		}
		
	}
}
