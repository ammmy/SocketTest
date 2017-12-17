using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
	[SerializeField]
	PingPoing pingPoing;
	[SerializeField]
	float speed = 10;
	float prePositionX;
	float velocity;
	public bool direction;
	public bool detected;
	public Vector3 targetPosition;

	// Use this for initialization
	void Start ()
	{
		pingPoing.SetSpeed (speed);
		pingPoing.SetDistance (8);
	}

	public void Move ()
	{
		prePositionX = transform.position.x;
		pingPoing.Move ();
		pingPoing.UpdateT ();
		velocity = transform.position.x - prePositionX;
		if (velocity != 0)
			direction = velocity > 0;
	}

	public void SensorValue (bool _detected, Vector3 _targetPosition)
	{
		targetPosition = _targetPosition;
		detected = _detected;
	}
}