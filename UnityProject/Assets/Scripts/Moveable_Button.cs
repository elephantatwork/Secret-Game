using UnityEngine;
using System.Collections;

public class Moveable_Button : MonoBehaviour {



	private Rigidbody localRigidbody;

	// Use this for initialization
	void Start () {
	
		localRigidbody = this.gameObject.AddComponent<Rigidbody>();

		//Heavy Type
		localRigidbody.drag = 15.0F;
		localRigidbody.angularDrag = 1.0F;

		localRigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
		localRigidbody.useGravity = false;
	}

//	public void
}
