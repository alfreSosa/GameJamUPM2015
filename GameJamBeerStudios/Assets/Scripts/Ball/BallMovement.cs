using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {

	public float X = 0;
	public float Y = -3.5f;
	public float speedMovement = 10.0f;
	private Rigidbody2D rb2D;
	private bool initMovement = false;
	void Start () {
		rb2D = GetComponent<Rigidbody2D> ();
	}
	

	void FixedUpdate() {

	}

	public void InitMovement(Vector3 angle) {
		if (!initMovement) {
			transform.eulerAngles = angle;
			initMovement = true;
			rb2D.AddForce (new Vector2(transform.up.x,transform.up.y) * speedMovement, ForceMode2D.Impulse);
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {

	}

	public void Reset()
	{
		transform.position = new Vector3 (X, Y, 0);
		rb2D.velocity = new Vector3 (0, 0, 0);
		initMovement = false;
		transform.eulerAngles = new Vector3 (0, 0, 0);
	}
}
