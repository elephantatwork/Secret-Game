using UnityEngine;
using System.Collections;

public class Compass : MonoBehaviour {

	public GameObject linkedTransform;

	// Update is called once per frame
	void Update () {

		if(linkedTransform == null){

			linkedTransform = GameObject.Find("Player");
			return; 
				
		}

		this.transform.rotation = linkedTransform.transform.rotation;
	}
}
