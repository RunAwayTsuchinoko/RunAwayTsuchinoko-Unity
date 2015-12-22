using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Main : MonoBehaviour
{
	private GameObject touchObject;
    
	// Use this for initialization
	void Start ()
	{
	}
    
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			Vector2 worldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
            
			RaycastHit2D hit = Physics2D.Raycast (worldPoint, Vector2.zero);
			if (hit) {
				// スタートボタンの場合
				if (hit.collider.gameObject.tag == "Start Button") {
					StartButton sb = hit.collider.gameObject.GetComponent<StartButton> ();
					sb.TouchDown ();
				}

				// つちのこの場合
				if (hit.collider.gameObject.tag == "Run Away") {
					this.touchObject = hit.collider.gameObject;

					TouchObject to = this.touchObject.GetComponent<TouchObject> ();
					to.TouchDown (worldPoint);
				}
			}
		} else if (Input.GetMouseButton (0)) {
			if (this.touchObject == null) {
				return;
			}

			Vector2 worldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			TouchObject to = this.touchObject.GetComponent<TouchObject> ();
			to.TouchMove (worldPoint);
		} else if (Input.GetMouseButtonUp (0)) {
			if (this.touchObject == null) {
				return;
			}

			this.touchObject = null;
		}
	}
}
