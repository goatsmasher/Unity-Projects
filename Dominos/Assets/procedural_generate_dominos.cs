using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class procedural_generate_dominos : MonoBehaviour {
	public GameObject to_replicate;
	public int how_many;
	

	// Use this for initialization
	void Start () {
		Vector3 originalPos = gameObject.transform.position;
		for(var i = 1; i <= how_many; i++){
			Instantiate(to_replicate,(originalPos + new Vector3(0, 0 ,i * 2.2f)), Quaternion.identity);
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
