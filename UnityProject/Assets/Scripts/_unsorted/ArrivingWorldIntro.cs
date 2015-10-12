using UnityEngine;
using System.Collections;

public class ArrivingWorldIntro : MonoBehaviour {

	Transform playerTransform;
	Transform introDistance;

	bool entered = false;

	// Use this for initialization
	void Start () {
		playerTransform = Camera.main.transform;
		introDistance = this.transform.FindChild("IntroDistance");
	
	}

	private void Update(){

		this.transform.rotation = playerTransform.rotation;
	}
	
	// Update is called once per frame
	public void AdvanceToPlayer (float _distance) {


		introDistance.transform.localPosition = new Vector3(0.0F, 0.0F, introDistance.transform.localPosition.z - _distance);
//		this.transform.RotateAround(playerTransform.position, Vector3.up, Vector3.Cross(this.transform.position, playerTransform.position).magnitude);
		                                                                     
	}
}
