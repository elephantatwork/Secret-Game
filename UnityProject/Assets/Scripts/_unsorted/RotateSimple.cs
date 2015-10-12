using UnityEngine;
using System.Collections;

public class RotateSimple : MonoBehaviour {

	private Transform localTransform;

	public Vector3 rotation;

	public bool world;

	// Use this for initialization
	void Start () {
		localTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {

		if(world)
			localTransform.Rotate(rotation*Time.deltaTime, Space.World);
		else
			localTransform.Rotate(rotation*Time.deltaTime);
	}
}
