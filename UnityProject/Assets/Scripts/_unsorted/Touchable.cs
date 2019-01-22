using UnityEngine;
using System.Collections;

public class Touchable : MonoBehaviour {

	public Rigidbody localRigidbody;

	public Color target_Color;
	public float fade_Time;
	
	public float normalizeTimer = 0.0F;

	public Interactive localIC;

	public virtual void Start(){

		localRigidbody = this.GetComponent<Rigidbody>();

		if(localRigidbody == null){
			localRigidbody = this.gameObject.AddComponent<Rigidbody>();
		}

		if(this.transform.parent != null)
			localIC = this.transform.parent.GetComponent<Interactive>();
		else
			localIC = this.GetComponent<Interactive>();

//		if(localRigidbody = null){
//			this.gameObject.AddComponent<Rigidbody>();
//			localRigidbody = this.GetComponent<Rigidbody>();
//		}
//
//		if(localIC = null)
//			localIC = this.gameObject.AddComponent<Interactive>();

	}

	public virtual void Update(){
		
		normalizeTimer = Mathf.Clamp(normalizeTimer - Time.deltaTime, 0.0F, 100.0F);

		int _id = 0;

		if(localIC != null)
			_id = localIC.localID ;
			
		if(localRigidbody.velocity.magnitude <= 0.1F && localRigidbody.angularVelocity.magnitude <= 0.02F && normalizeTimer <= 0.0F){
			target_Color =  Helper.instance.Interaction_Colors[_id].color_States[1];
			fade_Time = 2.2F;
		}

		Debug.Log(target_Color);
		
		iTween.ColorUpdate(gameObject, target_Color, fade_Time);
	}
}
