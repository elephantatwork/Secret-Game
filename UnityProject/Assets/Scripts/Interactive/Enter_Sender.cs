using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enter_Sender : Interactive {
	
	public void Initialize(){
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


		linkedIC.GetChange(localID, _newState);//state);
	}
}
