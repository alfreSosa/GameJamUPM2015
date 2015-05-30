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
	private GameObject[] balls;
	private GameManager gManager;
	private bool isMagnetic = false;
	public bool possesedBall = false;

	void Start () {
		initiated = false;
		arrow = transform.FindChild("Arrow");
		mEulerAngles = arrow.localEulerAngles;
		gManager = GameObject.FindGameObjectWithTag (Tags.gameManager).GetComponent<GameManager> ();
	}
	

	void Update () {
		balls = GameObject.FindGameObjectsWithTag (Tags.ball);
		m_movementBall = balls[0].GetComponent<BallMovement> ();
		if (Input.GetAxis ("Throw") != 0.0f && possesedBall) {
			arrow.GetComponent<SpriteRenderer>().enabled = false;
			initiated = true;
			possesedBall = false;
			m_movementBall.InitMovement (mEulerAngles, transform.gameObject);
		}
		if (!initiated && possesedBall) {
			mEulerAngles = new Vector3(mEulerAngles.x, mEulerAngles.y, mEulerAngles.z + ArrowSpeed * Time.deltaTime * direction);
			if (mEulerAngles.z >= 45)
				direction = -1;
			if (mEulerAngles.z <= -45 )
				direction = 1;
			arrow.localEulerAngles = mEulerAngles;
			balls[0].transform.position = transform.position + transform.up * offsetBall;
			
		}
	}

	public void Reset() {
		possesedBall = false;
		transform.position = new Vector3 (X, Y, 0);
		GetComponent<MovementCube>().ResetMovement ();
		arrow.GetComponent<SpriteRenderer>().enabled = true;
		initiated = false;
		mEulerAngles = new Vector3 (0, 0, 0);
		arrow.localEulerAngles = mEulerAngles;
		direction = 1;
		balls = GameObject.FindGameObjectsWithTag (Tags.ball);
		balls[0].transform.position = transform.position + transform.up * offsetBall;
		if (balls.Length > 1)
			for (int i = 1; i < balls.Length; i++)
				Destroy (balls [i]);
	}

	
	public void SetMagnetic(bool magnetic) {
		isMagnetic = magnetic;
	}

	public bool GetMagnetic() {
		return isMagnetic && !possesedBall;
	}

	public void ResetMagnetic(GameObject b) {
		possesedBall = true;
		arrow.GetComponent<SpriteRenderer>().enabled = true;
		initiated = false;
		mEulerAngles = new Vector3 (0, 0, 0);
		arrow.localEulerAngles = mEulerAngles;
		direction = 1;

		b.transform.position = transform.position + transform.up * offsetBall;
		b.transform.eulerAngles = new Vector3 (0, 0, 0);
		b.GetComponent<Rigidbody2D>().velocity = new Vector3 (0, 0, 0);
		b.GetComponent<BallMovement>().SetInitMovement(false);
		isMagnetic = false;
	}

	public bool isInitiated() {
		return initiated;
	}

}
