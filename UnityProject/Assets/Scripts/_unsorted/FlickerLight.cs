using UnityEngine;
using System.Collections;

public class FlickerLight : MonoBehaviour {

	private float maxValue;
	private Transform light_Sprite;

	// Use this for initialization
	void Start () {
	
		light_Sprite = transform.Find("Light_Sprite");

		light_Sprite.GetComponent<Renderer>().material.SetColor("_TintColor", this.GetComponent<Light>().color);

		maxValue = this.GetComponent<Light>().intensity;
	}
	
	// Update is called once per frame
	void Update () {

		this.GetComponent<Light>().intensity = Mathf.Clamp( this.GetComponent<Light>().intensity + Random.Range(-maxValue, maxValue), 0, maxValue);

		light_Sprite.localScale = Vector3.one * Mathf.Pow(this.GetComponent<Light>().intensity,2);
	}
}
