using UnityEngine;
using System.Collections;

public class Savepoint : Reciever {

	public override void Activate ()
	{
		base.Activate ();

		SecretsMaster.instance.SaveGame();
	}

//	public override void Deactivate ()
//	{
//		base.Deactivate ();
//	}
}
