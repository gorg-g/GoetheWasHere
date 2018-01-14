using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class InitVuforia : MonoBehaviour 
{
	void Start () 
	{
		VuforiaBehaviour.Instance.enabled = true;
	}
}
