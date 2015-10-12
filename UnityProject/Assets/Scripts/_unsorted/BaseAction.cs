using UnityEngine;
using System.Collections;

public class BaseAction : MonoBehaviour {

	// Use this for initialization
	void Awake () {
	
	}
	
	// Update is called once per frame
	public virtual void Action() {
	
		print ("Hit Object: " + this.name);
	}

}
