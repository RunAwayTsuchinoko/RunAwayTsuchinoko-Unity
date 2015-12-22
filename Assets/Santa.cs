using UnityEngine;
using System.Collections;

public class Santa : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		iTween.MoveTo (gameObject, iTween.Hash ("x", 15, "time", 30, "delay", 0, "easeType", iTween.EaseType.linear, "oncomplete", "OnCompleteHandler", "loopType", "loop"));	
	}

	void OnCompleteHandler ()
	{
	}

	// Update is called once per frame
	void Update ()
	{
	}
}
