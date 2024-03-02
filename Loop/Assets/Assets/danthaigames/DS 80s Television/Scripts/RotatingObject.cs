using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObject : MonoBehaviour {

	public float rotationSpeed = 0;

	void Update () {
		transform.Rotate (0, Time.deltaTime * rotationSpeed, 0);	
	}
}
