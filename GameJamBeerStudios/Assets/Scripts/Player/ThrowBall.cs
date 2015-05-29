using UnityEngine;
using System.Collections;

public class ThrowBall : MonoBehaviour {
	
	public float ArrowSpeed = 50.0f;
	public float X = 0;
	public float Y = -4;

	private BallMovement m_movementBall;
	private Transform arrow;
	private bool initiated = false;
	private int direction = 1;
	private Vector3 mEulerAngles = new Vector3(0,0,0);

	void Start () {
		initiated = false;
		arrow = transform.FindChild("Arrow");
		mEulerAngles = arrow.eulerAngles;
		GameObject ball = GameObject.FindGameObjectWithTag (Tags.ball);
		m_movementBall = ball.GetComponent<BallMovement> ();
	}
	

	void Update () {
		if (Input.GetAxis ("Throw") != 0.0f) {
			arrow.GetComponent<SpriteRenderer>().enabled = false;
			initiated = true;
			m_movementBall.InitMovement (mEulerAngles);
		}
		if (!initiated) {
			mEulerAngles = new Vector3(mEulerAngles.x, mEulerAngles.y, mEulerAngles.z + ArrowSpeed * Time.deltaTime * direction);
			if (mEulerAngles.z >= 45)
				direction = -1;
			if (mEulerAngles.z <= -45 )
				direction = 1;
			arrow.eulerAngles = mEulerAngles;
		}
	}

	void Reset() {
		transform.position = new Vector3 (X, Y, 0);
		initiated = false;
		arrow.GetComponent<SpriteRenderer>().enabled = true; 
		mEulerAngles = new Vector3 (0, 0, 0);

	}
}
