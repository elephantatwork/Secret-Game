using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sender : Interactive {
	
	public virtual void Initialize(){
		Change (state);
	}

	private void OnMouseDown(){

		Change(!state);
	}

	public override void Change (bool _newState)
	{
		if(linkedIC == null){
			Debug.LogWarning("Missing Interactive Core on Sender :" + this.name);
			return;
		}

		base.Change (_newState);

		linkedIC.GetChange(localID, state);
	}
}
