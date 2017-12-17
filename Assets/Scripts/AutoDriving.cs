using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDriving : MonoBehaviour
{
	[SerializeField]
	Car car;
	public bool cond0, cond1, cond2;

	// Use this for initialization
	void Start ()
	{
		StartCoroutine (Run ());
	}

	bool IsSafe ()
	{
		cond0 = car.detected;
		cond1 = car.direction == car.targetPosition.x > 0;
		cond2 = Mathf.Abs (car.targetPosition.z) < 2;
		car.detected = false;
		return !(cond0 && cond1 && cond2);
	}

	IEnumerator Run ()
	{
		while (true) {
			if (IsSafe ()) {
				car.Move ();
			}
			yield return null;
		}
	}
}