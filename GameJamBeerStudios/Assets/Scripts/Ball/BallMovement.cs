using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {

	public float speedMovement = 5.0f;
	public float desviation = 0.1f;
	private Rigidbody2D rb2D;
	private bool initMovement = false;
	void Start () {
		rb2D = GetComponent<Rigidbody2D> ();
	}
	

	void FixedUpdate() {
		if (initMovement)
			rb2D.AddForce(transform.up * speedMovement);
	}

	public void InitMovement() {
		initMovement = true;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		GameObject ball = collision.gameObject;
		if (ball.tag != Tags.item) {
			Vector3 eulerAngles = ball.transform.eulerAngles;
			Vector3 newEulerAngles = new Vector3(eulerAngles.x, eulerAngles.y, -eulerAngles.z);
			ball.transform.eulerAngles = newEulerAngles;
		}
	}
}
