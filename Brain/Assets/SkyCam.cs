using UnityEngine;
using System.Collections;

public class SkyCam : MonoBehaviour {

	public float turnVal = 10.0f;
	private Vector3 rotationValue;
	
	void LateUpdate ()
	{
		turnVal += Time.deltaTime;
		rotationValue = new Vector3 (Camera.main.transform.rotation.eulerAngles.x, Camera.main.transform.rotation.eulerAngles.y + turnVal, Camera.main.transform.rotation.eulerAngles.z);
		transform.rotation = Quaternion.Euler (rotationValue);
	}
}
