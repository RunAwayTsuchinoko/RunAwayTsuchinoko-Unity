using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LOS : MonoBehaviour
{
	//追跡対象
	public GameObject objTarget;
	
	//今までいた位置を保持
	public Vector2 prev;
	
	public Vector2 firstPosition;

	public GameObject startButton;
	public GameObject top;

	public Text highScoreText;
	public Text scoreText;
	private float prevScore = 0.0f;
	private float score = 0.0f;
	private bool isStart = false;
	private Sprite gameover;
	private Sprite oninoko;

	private GameObject deadSound;
	private EventObjectSound deadSoundObject;

	//初期化処理
	void Start ()
	{
		this.firstPosition = transform.position;

		this.gameover = Resources.Load<Sprite> ("Textures/oninoko_clear");
		this.oninoko = Resources.Load<Sprite> ("Textures/oninoko");

		this.deadSound = GameObject.Find ("Dead Sound");
		this.deadSoundObject = this.deadSound.GetComponent<EventObjectSound> ();

		iTween.MoveBy (gameObject, iTween.Hash ("x", -5, "time", 0, "delay", 0, "oncomplete", "OnCompleteHandler"));
	}

	void OnCompleteHandler ()
	{
		iTween.MoveBy (gameObject, iTween.Hash ("x", 5, "time", 0.5f, "delay", 0, "easeType", iTween.EaseType.easeInOutBack));
	}

	void Update ()
	{
		if (!this.isStart) {
			return;
		}

		Move (); 

		this.score += Time.deltaTime;
		this.scoreText.text = "Score: " + this.score.ToString ("f2");
	}

	public void StartAnimation ()
	{
		this.prev = transform.position;

		GetComponent<SpriteRenderer> ().sprite = this.oninoko;

		this.prevScore = 0.0f;
		this.scoreText.text = "Score: 0";

		this.isStart = true;
	}

	//移動関数
	void Move ()
	{
		//ユーザの場所を特定
		Vector2 Predetor = objTarget.transform.position;
		
		float x = Predetor.x;
		float y = Predetor.y;
		//追跡方向の決定
		Vector2 direction = new Vector2 (x - transform.position.x, y - transform.position.y).normalized;
		//ターゲット方向に力を加える
		GetComponent<Rigidbody2D> ().velocity = (direction * (2 + (this.score)));
		
		//本体の向きを調整
		Vector2 Position = transform.position;  
		Vector2 diff = Position - prev;
		if (diff.magnitude > 0.01) {
			float angle = Mathf.Atan2 (diff.y, diff.x) * Mathf.Rad2Deg;
			// float angle = Mathf.Atan2 (diff.y, diff.x) * Mathf.Rad2Deg - 90;
			transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		} 
		//次回角度計算のために現在位置を保持
		prev = Position;
	}

	void OnTriggerEnter2D (Collider2D collision)
	{
		if (collision.gameObject.tag != "Run Away") {
			return;
		}

		Debug.Log ("Game Over");

		this.isStart = false;

		this.deadSoundObject.PlaySoundOneShot ();

		GetComponent<SpriteRenderer> ().sprite = this.gameover;
		GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		transform.rotation = Quaternion.identity;

		transform.position = this.firstPosition;

		this.scoreText.text = "Score: " + this.score.ToString ("f2");

		if (this.score > this.prevScore) {
			this.highScoreText.text = "HighScore: " + this.score.ToString ("f2");
			this.prevScore = this.score;
		}

		this.score = 0.0f;

		this.startButton.SetActive (true);
		this.top.SetActive (true);
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
