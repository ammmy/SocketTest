using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passerby : MonoBehaviour
{
	[SerializeField]
	PingPoing pingPoing;
	[SerializeField]
	float speed = 1;


	// Use this for initialization
	void Start ()
	{
		pingPoing.SetAuto (true);
		pingPoing.SetAxis ("z");
		pingPoing.SetSpeed (speed);
	}
}
