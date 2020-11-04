using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour {

	public float th = 0;
	public float x = 0;
	public float z = 0;
	public float y = 0;
	


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(5*x,5*z,5*y);
	}
}
