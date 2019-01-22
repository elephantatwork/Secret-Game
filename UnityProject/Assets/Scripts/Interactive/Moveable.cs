using UnityEngine;
using System.Collections;

public class Moveable : Touchable {


	public bool rotation_Enabled;
	public bool move_X;
	public bool move_Y;
	public bool move_Z;

//	private enum heavyTypes;


	// Use this for initialization
	public override void Start ()
	{
		base.Start ();

		//Heavy Type
		localRigidbody.drag = 15.0F;
		localRigidbody.angularDrag = 1.0F;


		RigidbodyConstraints _constraints = new RigidbodyConstraints();

		if(rotation_Enabled)
			_constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
		else
			_constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

		if(!move_X)
			_constraints |= RigidbodyConstraints.FreezePositionX;

		if(!move_Y)
			_constraints |= RigidbodyConstraints.FreezePositionY;

		if(!move_Z)
			_constraints |= RigidbodyConstraints.FreezePositionZ;

		localRigidbody.constraints = _constraints;

		localRigidbody.useGravity = false;
	}


}
