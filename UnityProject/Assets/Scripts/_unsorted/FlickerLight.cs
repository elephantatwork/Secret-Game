using UnityEngine;
using System.Collections;

public class FlickerLight : MonoBehaviour {

	private float maxValue;

	// Use this for initialization
	void Start () {
	
		maxValue = this.GetComponent<Light>().intensity;
	}
	
	// Update is called once per frame
	void Update () {

		this.GetComponent<Light>().intensity = Mathf.Clamp( this.GetComponent<Light>().intensity + Random.Range(-maxValue, maxValue), 0, maxValue);
	}
}
