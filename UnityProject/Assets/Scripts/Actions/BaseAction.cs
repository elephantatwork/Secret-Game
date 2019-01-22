using UnityEngine;
using System.Collections;

public class BaseAction : Reciever {

	public override void Initialize ()
	{
//		base.Initialize ();

	}

	public override void Change (bool _newState)
	{
//		base.Change (_newState);

		Action (_newState);
	}

	// Update is called once per frame
	public virtual void Action(bool _state) {
	
		print ("Hit Object: " + this.name + " with State " + _state);
	}

}
