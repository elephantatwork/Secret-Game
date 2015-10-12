using UnityEngine;
using System.Collections;

public class shrink : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(this.transform.localScale.x > 0.0F)
		this.transform.localScale -= Vector3.one * Time.deltaTime/10.0F;
	}
}
