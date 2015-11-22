using UnityEngine;
using System.Collections;

public class MainMenuAnim : MonoBehaviour {

	public float delay = 5.0f;
	private float lastAnim;
	public UnityStandardAssets.ImageEffects.BloomOptimized Bloom;
	
	public float value;
	
	public float speed = 10.0f;
	public float maxDist = 1.0f;
	private float vel;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
//		if (Time.time >= lastAnim + delay)
//		{
//			print ("blah");
//			lastAnim = Time.time;
			//Bloom.threshold = Mathf.SmoothDamp(Bloom.threshold, Random.Range(0.0f, 1.5f) ,ref  vel, 10 * Time.deltaTime);
			value = Mathf.PingPong(Time.time * Random.Range (speed - 0.01f, speed), maxDist);
			Bloom.threshold = value;
			
			
			
//		}
	}
}
