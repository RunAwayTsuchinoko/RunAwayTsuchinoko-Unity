using UnityEngine;
using System.Collections;

public class UFO : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		iTween.MoveBy (gameObject, iTween.Hash ("y", 0.5, "time", 2, "delay", 0, "easeType", iTween.EaseType.linear, "loopType", "pingPong"));	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
