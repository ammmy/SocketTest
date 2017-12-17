using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPoing : MonoBehaviour
{
	float t;
	float speed = 2;
	[SerializeField]
	float distance = 8;
	Vector3 inipos;
	bool auto = false;
	string axis = "x";

	// Use this for initialization
	void Start ()
	{
		inipos = transform.position;
	}

	// Update is called once per frame
	void Update ()
	{
		if (auto) {
			Move ();
			UpdateT ();
		}
	}

	public void SetSpeed (float s)
	{
		speed = s;
	}

	public void SetDistance (float d)
	{
		distance = d;
	}

	public void SetAuto (bool b)
	{
		auto = b;
	}

	public void SetAxis (string s)
	{
		axis = s;
	}

	public void Move ()
	{
		Vector3 p = inipos;
		float d = Mathf.PingPong (t, distance);
		if (axis == "x")
			p.x += d;
		else if (axis == "z")
			p.z += d;
		transform.position = p;
	}

	public void UpdateT ()
	{
		t += speed * Time.deltaTime;
	}
}