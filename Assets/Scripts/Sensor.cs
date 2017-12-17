using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
	string tagPasserby = "Passerby";
	Car car;
	Vector3 targetPosition;
	bool detected;

	// Use this for initialization
	void Start ()
	{
		car = transform.parent.GetComponent<Car> ();
	}

	// Update is called once per frame
	void Update ()
	{
		car.SensorValue(detected, targetPosition);
		detected = false;
	}

	void OnTriggerStay (Collider collider)
	{
		if (collider.gameObject.tag == tagPasserby){
			targetPosition = collider.gameObject.transform.position - transform.position;
			detected = true;
		}
	}
}