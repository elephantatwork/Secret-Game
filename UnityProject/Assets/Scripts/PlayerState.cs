using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerState{
	
	public float posX;
	public float posY;
	public float posZ;


	public PlayerState(){

		Debug.Log(System.Attribute.IsDefined(typeof(Vector3), typeof(System.SerializableAttribute))); //prints true in 4.3.4f1

//		posX = posY = posZ = 0.0F;

	}
} 
