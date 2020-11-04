using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

	main mains;

	Sphere sphere;
	Quaternion initRotation;

	void Awake()
	{
		mains = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<main>();
		initRotation = Quaternion.identity;
		sphere = GameObject.Find("Sphere").GetComponent<Sphere>(); 
	}
		
	void Start () 
	{
		InvokeRepeating("checkfps", 0,5);
	}
	// Update is called once per frame
	void Update () 
	{
		string x = mains.receivedData.Split(':')[0].Trim('\"');
		string y = mains.receivedData.Split(':')[1].Trim('\"');
		string z = mains.receivedData.Split(':')[2].Trim('\"');
		string th = mains.receivedData.Split(':')[3].Trim('\"');

		try
		{
			float xr = float.Parse(x);
		    float yr = float.Parse(y);
		    float zr = float.Parse(z);
			float thr = float.Parse(th);

			//debug용.
			/*
			float real_theta = Mathf.Acos(thr) * 2;
			float sin_abs_half = Mathf.Sin(real_theta / 2);
			float real_x = xr / sin_abs_half;
			float real_y = yr / sin_abs_half;
			float real_z = zr / sin_abs_half;
			float unity_th = real_theta / Mathf.PI * 180;
			float unity_x = real_x;
			float unity_y = real_y;
			float unity_z = real_z;
			sphere.th = unity_th;
			sphere.x = unity_x;
			sphere.y = unity_y;
			sphere.z = unity_z;
			*/
			
			Quaternion qu = Quaternion.Inverse(new Quaternion(xr,zr,yr,thr));
			qu = initRotation * qu;
			transform.rotation = qu;

		}
		catch (System.Exception e)
		{
			Debug.Log(e);
		}
	}

	void checkfps()
	{
		var fps = mains.count / 5;
		mains.count = 0;
		Debug.Log("fps:" + fps.ToString());
	}

	public void initializeRotation()
	{
		string x = mains.receivedData.Split(':')[0].Trim('\"');
		string y = mains.receivedData.Split(':')[1].Trim('\"');
		string z = mains.receivedData.Split(':')[2].Trim('\"');
		string th = mains.receivedData.Split(':')[3].Trim('\"');

		try
		{
			float xr = float.Parse(x);
		    float yr = float.Parse(y);
		    float zr = float.Parse(z);
			float thr = float.Parse(th);
			
			initRotation = new Quaternion(xr,zr,yr,thr);

		}
		catch (System.Exception e)
		{

		}
	}
}
