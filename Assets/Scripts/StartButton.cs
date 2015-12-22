using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour
{

	public GameObject runAway;
	public GameObject chase;
	public GameObject top;

	private LOS los;
	private TouchObject to;

	private GameObject startSound;
	private EventObjectSound startSoundObject;

	// Use this for initialization
	void Start ()
	{
		this.to = runAway.GetComponent<TouchObject> ();
		this.los = chase.GetComponent<LOS> ();

		this.startSound = GameObject.Find ("Start Sound");
		this.startSoundObject = this.startSound.GetComponent<EventObjectSound> ();

		Invoke ("FadeOut", 0f);
		Invoke ("FadeIn", 0.2f);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void FadeIn ()
	{
		// SetValue()を毎フレーム呼び出して、１秒間に０から１までの値の中間値を渡す
		iTween.ValueTo (gameObject, iTween.Hash ("from", 0f, "to", 1f, "time", 0.5f, "onupdate", "SetValue"));
	}

	void FadeOut ()
	{
		// SetValue()を毎フレーム呼び出して、１秒間に１から０までの値の中間値を渡す
		iTween.ValueTo (gameObject, iTween.Hash ("from", 1f, "to", 0f, "time", 0.0f, "onupdate", "SetValue"));
	}

	void SetValue (float alpha)
	{
		// iTweenで呼ばれたら、受け取った値をImageのアルファ値にセット
		Color c = gameObject.GetComponent<SpriteRenderer> ().color;
		gameObject.GetComponent<SpriteRenderer> ().color = new Color (c.r, c.b, c.g, alpha);
	}

	public void TouchDown ()
	{
		gameObject.SetActive (false);

		this.startSoundObject.PlaySoundOneShot ();

		this.top.SetActive (false);

		this.to.StartAnimation ();
		this.los.StartAnimation ();
	}
}
