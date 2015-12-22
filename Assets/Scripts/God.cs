using UnityEngine;
using System.Collections;

public class God : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		iTween.MoveBy (gameObject, iTween.Hash ("y", -5, "time", 0, "delay", 0, "easeType", iTween.EaseType.easeInOutBack, "oncomplete", "OnCompleteHandler"));
	}

	void OnCompleteHandler ()
	{
		iTween.MoveBy (gameObject, iTween.Hash ("y", 5, "time", 0.5f, "delay", 0.5));	
	}

	// Update is called once per frame
	void Update ()
	{
	
	}
}
