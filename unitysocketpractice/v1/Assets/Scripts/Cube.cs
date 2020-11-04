using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

	main mains;

	int updatecount = 0;

	void Awake()
	{
		mains = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<main>();
	}
		
	void Start () 
	{
		InvokeRepeating("checkfps", 0,5);
		InvokeRepeating("checkupdatefps",0,5);
	}
	// Update is called once per frame
	void Update () 
	{
		string x = mains.receivedData.Split(':')[0].Trim('\"');
		string y = mains.receivedData.Split(':')[1].Trim('\"');
		string z = mains.receivedData.Split(':')[2].Trim('\"');

		try
		{
			float xr = float.Parse(x);
		    float yr = float.Parse(y);
		    float zr = float.Parse(z);
			transform.position = new Vector3(xr,yr,zr);
		}
		catch (System.Exception e)
		{

		}

		updatecount += 1;
		
	}

	void checkfps()
	{
		var fps = mains.count / 5;
		mains.count = 0;
		Debug.Log("fps:" + fps.ToString());
	}

	void checkupdatefps()
	{
		var upfps = updatecount / 5;
		updatecount = 0;
		Debug.Log("Update func. fps:" + upfps.ToString());
	}
}
