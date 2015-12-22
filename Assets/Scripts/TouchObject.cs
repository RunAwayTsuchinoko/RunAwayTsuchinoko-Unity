using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchObject : MonoBehaviour
{
	public Vector2 firstPosition;
	private bool isStart = false;

	private Sprite gameover;
	private Sprite tsutinoko;

	// Use this for initialization
	void Start ()
	{
		this.firstPosition = transform.position;

		this.gameover = Resources.Load<Sprite> ("Textures/tsuchinoko_clear");
		this.tsutinoko = Resources.Load<Sprite> ("Textures/tsuchinoko");

		iTween.MoveBy (gameObject, iTween.Hash ("x", 5, "time", 0, "delay", 0, "oncomplete", "OnCompleteHandler"));	
	}

	void OnCompleteHandler ()
	{
		iTween.MoveBy (gameObject, iTween.Hash ("x", -5, "time", 0.5f, "delay", 0.2, "easeType", iTween.EaseType.easeInOutBack));
	}

	// Update is called once per frame
	void Update ()
	{
		if (!this.isStart) {
			return;
		}
	}

	public void StartAnimation ()
	{
		this.isStart = true;

		GetComponent<SpriteRenderer> ().sprite = this.tsutinoko;
	}

	public void TouchDown (Vector2 point)
	{
	}

	public void TouchMove (Vector2 point)
	{
		if (!this.isStart) {
			return;
		}

		gameObject.transform.position = point;
	}

	public void TouchUp (Vector2 point)
	{
	}

	public void FadeOut ()
	{
	}

	void OnTriggerEnter2D (Collider2D collision)
	{
		if (collision.gameObject.tag != "Chase") {
			return;
		}

		Debug.Log ("Game Over");

		GetComponent<SpriteRenderer> ().sprite = this.gameover;

		transform.position = this.firstPosition;

		this.isStart = false;
	}

	void OnTriggerStay2D (Collider2D collision)
	{ 
	}

	void OnTriggerExit2D (Collider2D collision)
	{ 
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
	}

	void OnCollisionStay2D (Collision2D collision)
	{
	}

	void OnCollisionExit2D (Collision2D collision)
	{ 
	}

	private void DestroyEventHandler ()
	{
		DestroyObject ();
	}

	private void DestroyObject ()
	{
		foreach (Transform t in transform) {
			Destroy (t.gameObject.GetComponent<Renderer> ().material);
			Destroy (t.gameObject);
		}
		Destroy (gameObject.GetComponent<Renderer> ().material);
		Destroy (gameObject);
	}
    
}
