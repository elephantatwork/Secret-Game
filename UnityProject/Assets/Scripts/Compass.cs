using UnityEngine;
using System.Collections;

public class Compass : MonoBehaviour {

	public Transform linkedTransform;

	// Update is called once per frame
	void Update () {
		this.transform.rotation = linkedTransform.rotation;
	}
}
