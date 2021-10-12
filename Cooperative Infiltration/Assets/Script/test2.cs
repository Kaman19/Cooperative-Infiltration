using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test2 : MonoBehaviour
{

    [SerializeField]
    Transform mytarget;

	[SerializeField]
    testNW nwScript;
	private void OnTriggerEnter(Collider other)
	{
		
		if (other.tag=="test")
		{
			
			nwScript.target = mytarget;
		}
	}
}
