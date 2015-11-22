using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonFlash : MonoBehaviour {
	
	private float value;
	private Text text;
	public float speed = 10.0f;
	private float maxDist = 1.0f;
	
	// Use this for initialization
	void Start () 
	{
		text = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () 
	{	
		text.color = new Vector4(1,1,1, Mathf.PingPong(Time.time * speed, maxDist));
	
	}
	
	public void PlayGame ()
	{
		Application.LoadLevel (1);
	}
}
