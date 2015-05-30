using UnityEngine;
using System.Collections;

public class ThrowBall : MonoBehaviour {
	
	public float X = 0;
	public float Y = -4;
	public float offsetBall = 0.5f;
	public float ArrowSpeed = 50.0f;

	private BallMovement m_movementBall;
	private Transform arrow;
	private bool initiated = false;
	private int direction = 1;
	private Vector3 mEulerAngles = new Vector3(0,0,0);
	private GameObject ball;
	private GameManager gManager;
	void Start () {
		initiated = false;
		arrow = transform.FindChild("Arrow");
		mEulerAngles = arrow.localEulerAngles;
		ball = GameObject.FindGameObjectWithTag (Tags.ball);
		m_movementBall = ball.GetComponent<BallMovement> ();
		gManager = GameObject.FindGameObjectWithTag (Tags.gameManager).GetComponent<GameManager> ();
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
			arrow.localEulerAngles = mEulerAngles;
			ball.transform.position = transform.position + transform.up * offsetBall;
			
		}
	}

	public void Reset() {
		transform.position = new Vector3 (X, Y, 0);
		arrow.GetComponent<SpriteRenderer>().enabled = true;
		initiated = false;
		mEulerAngles = new Vector3 (0, 0, 0);
		arrow.localEulerAngles = mEulerAngles;
		direction = 1;
		ball = GameObject.FindGameObjectWithTag (Tags.ball);
		ball.transform.position = transform.position + transform.up * offsetBall;
	}
}
