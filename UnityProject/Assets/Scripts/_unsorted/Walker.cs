using UnityEngine;
using System.Collections;

public class Walker : MonoBehaviour
{

	private float currentWalkSpeed;
	public float normalWalk;
	public float fastWalk;
	private float currentStrafeSpeed;
	public float normalStrafe;
	public float fastStrafe;
	private float currentRotationSpeed; // Used as degrees per second

	public float normalRotation;
	public float fastRotation;
	private Vector3 moveVector;
	private float pushingSpeedReduction = 0.8F;
	private Transform localTransform;
	private Rigidbody localRigidbody;
	private CharacterController localCharacter;
	public ArrivingWorldIntro _linkToINTRO;
	private float pushPower = 2.0F;
	private bool rotating = false;
	private bool moving = false;
	public float movingValue = 0.0F;
	public float rotationValue = 0.0F;

	private enum soundStates
	{
	
		idle,
		forward,
		back,
		rotationLeft,
		rotationRight,

	}

	private enum rotationStates{

	}


	private soundStates currentSoundState;

	// Use this for initialization
	void Start ()
	{
	
		localTransform = this.transform;
		localRigidbody = this.GetComponent<Rigidbody> ();
		localCharacter = this.GetComponent<CharacterController> ();

		ToggleFast (false);	
	}
	
	// Update is called once per frame
	void Update ()
	{

		   
		if (Input.GetKey (KeyCode.A))
			Turn (-1);

		if (Input.GetKey (KeyCode.D))
			Turn (1);

		if (Input.GetKey (KeyCode.W))
			Move (1);

		if (Input.GetKey (KeyCode.S))
			Move (-1);

		//New Inputs
		//Get reset
		if (Input.GetKeyUp (KeyCode.W))
			MoveNew (-1);
		
		if (Input.GetKeyUp (KeyCode.S))
			MoveNew (1);
		
		if (Input.GetKeyUp (KeyCode.A))
			TurnNew (1);
		
		if (Input.GetKeyUp (KeyCode.D))
			TurnNew (-1);

		if (Input.GetKeyDown (KeyCode.A))
			TurnNew (-1);
	   
		if (Input.GetKeyDown (KeyCode.D))
			TurnNew (1);
	   
		if (Input.GetKeyDown (KeyCode.W))
			MoveNew (1);
	   
		if (Input.GetKeyDown (KeyCode.S))
			MoveNew (-1);



//		if(Input.GetKey(KeyCode.A))
//			Strafe(-1);
//		
//		if(Input.GetKey(KeyCode.D))
//			Strafe(1);

		if (Input.GetKeyDown (KeyCode.LeftShift))
			ToggleFast (true);

		if (Input.GetKeyUp (KeyCode.LeftShift))
			ToggleFast (false);

//		this.GetComponent<CharacterController>().Move(moveVector*Time.deltaTime);
			


//		if(localRigidbody.ve

		


//			Fabric.EventManager.Instance.SetGlobalSwitch("PlayerMovement", "playerForward");
			
//		}
	}

	private void Sound(soundStates _newState){

		if(_newState == soundStates.forward)
			Fabric.EventManager.Instance.SetGlobalSwitch("PlayerMovement", "playerForward");

		if(_newState == soundStates.back)
			Fabric.EventManager.Instance.SetGlobalSwitch("PlayerMovement", "playerBack");

		if(_newState == soundStates.rotationLeft)
			Fabric.EventManager.Instance.SetGlobalSwitch("PlayerRotation", "playerRotationLeft");

		if(_newState == soundStates.rotationRight)
			Fabric.EventManager.Instance.SetGlobalSwitch("PlayerRotation", "playerRotationRight");

		if(_newState == soundStates.idle)
			Fabric.EventManager.Instance.SetGlobalSwitch("PlayerMovement", "playerIdle");
	}

	private void ToggleFast (bool _state)
	{

		currentWalkSpeed = (_state) ? fastWalk : normalWalk;

		currentRotationSpeed = (_state) ? fastRotation : normalRotation;

		currentStrafeSpeed = (_state) ? fastStrafe : normalStrafe;
	}

	private void Move (int _direction)
	{
	
//		moveVector += localTransform.forward * _direction * walkSpeed;
		this.GetComponent<CharacterController> ().Move (localTransform.forward * _direction * currentWalkSpeed * Time.deltaTime);

//		moving = true;

//		movingValue += _direction;
//		currentSoundState = ( _direction) ? soundStates.forward: soundStates.back;
//		if(_direction)
//			Fabric.EventManager.Instance.sw

//		_linkToINTRO.AdvanceToPlayer(walkSpeed*Time.deltaTime);
	}

	private void MoveNew (int _direction)
	{
			
		//		moveVector += localTransform.forward * _direction * walkSpeed;
//		this.GetComponent<CharacterController> ().Move (localTransform.forward * _direction * currentWalkSpeed * Time.deltaTime);
			
//		moving = true;
			
		movingValue += _direction;
		//		currentSoundState = ( _direction) ? soundStates.forward: soundStates.back;
		//		if(_direction)
		//			Fabric.EventManager.Instance.sw
			
		//		_linkToINTRO.AdvanceToPlayer(walkSpeed*Time.deltaTime);

		if(movingValue == 1)
			Sound(soundStates.forward);
		else if(movingValue == -1)
			Sound(soundStates.back);
		else if(rotationValue == 0)
			Sound(soundStates.idle);

	}

	private void Strafe (int _direction)
	{

//		moveVector += localTransform.right * _direction * walkSpeed;
		this.GetComponent<CharacterController> ().Move (localTransform.right * _direction * currentWalkSpeed * Time.deltaTime);
	}

	private void Turn (int _direction)
	{

		//Rotate xDegrees 
		localTransform.Rotate(Vector3.up * _direction * currentRotationSpeed * Time.deltaTime);

//		rotating = true;

//		rotationValue += _direction;
//		currentSoundState = ( _direction) ? soundStates.rotationLeft: soundStates.rotationRight;

	}

	private void TurnNew (int _direction)
	{
			
		//Rotate xDegrees 
//			localTransform.Rotate(Vector3.up * _direction * currentRotationSpeed * Time.deltaTime);
			
//			rotating = true;
			
		rotationValue += _direction;

		if(rotationValue == 1)
			Sound(soundStates.rotationRight);
		else if(rotationValue == -1)
			Sound(soundStates.rotationLeft);
		else if(movingValue == 0)
			Sound(soundStates.idle);

//		if(_newState != null)
//			Sound(_newState);
		//		currentSoundState = ( _direction) ? soundStates.rotationLeft: soundStates.rotationRight;
			
	}

	public void OnControllerColliderHit (ControllerColliderHit _hit)
	{

//		Fabric.

		Rigidbody _otherBody = _hit.collider.attachedRigidbody;
		if (_otherBody == null || _otherBody.isKinematic)
			return;
		
		if (_hit.moveDirection.y < -0.3F)
			return;
		
		Vector3 pushDir = new Vector3 (_hit.moveDirection.x, 0, _hit.moveDirection.z);
		_otherBody.velocity = pushDir * currentWalkSpeed * pushingSpeedReduction;


	}


}
