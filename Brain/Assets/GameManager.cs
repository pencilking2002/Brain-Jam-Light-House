using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	private PlayerController3 playerController;
	
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
		GUI.Button(new Rect(0, 0, 150, 20), "At surface: " + playerController.atSurface);
	}
}
