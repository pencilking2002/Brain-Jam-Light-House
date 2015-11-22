using UnityEngine;
using System.Collections;

public class LightTrigger : MonoBehaviour {
	
	private Light theLight;
	public Material enabledMaterial;
	public Material normalMaterial;
	
	private static float initialRange = 0.0f;
	private static float finalIntensity = 1.0f;
	private static float finalRange = 30.0f;
	
	private MeshRenderer mRend;
	private Vector4 _color = Vector4.one;
	
	public Vector4 _newColor;
	private Vector4 _currentColor;
	
	private AudioSource aSource;
	
	private void Start ()
	{
			
		theLight = GetComponent<Light>();
		mRend = GetComponent<MeshRenderer>();
		
		normalMaterial = mRend.material;
		normalMaterial.EnableKeyword("_EMISSION");
		
		_currentColor = normalMaterial.GetColor("_Color");
		//print (_currentColor);
		_newColor.w = 2.0f;
		
		theLight.range = initialRange;
		theLight.color = _currentColor;
		
		aSource = transform.parent.GetComponent<AudioSource>();
		
	}
	
	public void EnableLight ()
	{
		theLight.enabled = true;
		//mRend.sharedMaterial = enabledMaterial;
		
		if (theLight.enabled)
			aSource.Play ();
			
		LeanTween.value(gameObject, 0, finalIntensity, 2.0f)
			.setOnUpdate((float value) => {
				theLight.intensity = value;		
			})
			.setEase(LeanTweenType.easeInSine);
		
		LeanTween.value(gameObject, 0, finalRange, 2.0f)
			.setOnUpdate((float value) => {
				theLight.range = value;		
			})
				.setEase(LeanTweenType.easeInSine);
			
		LeanTween.value(gameObject, 0, 2.0f, 2.0f)
			.setOnUpdate((float value) => {
				//mRend.material.SetFloat("_EmissionScaleUI", value);
				normalMaterial.SetColor("_EmissionColor", new Vector4 (_currentColor.x, _currentColor.y, _currentColor.z) * value);
			})
				.setEase(LeanTweenType.easeInSine);
			
			
		
	}
}
