using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotate : MonoBehaviour
{
	public float tumble;
	Rigidbody asteroid;
	void Start(){
		asteroid = GetComponent<Rigidbody>();
		asteroid.angularVelocity = Random.insideUnitSphere * tumble;
	}

}
