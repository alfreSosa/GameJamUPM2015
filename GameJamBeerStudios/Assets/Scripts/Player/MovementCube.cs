using UnityEngine;
using System.Collections;

public class MovementCube : MonoBehaviour {


	public float speedMovement = 10.0f;
	public float max_distance = 10.0f;

	private BallMovement m_movementBall;
	void Start () {
		GameObject ball = GameObject.FindGameObjectWithTag (Tags.ball);
		m_movementBall = ball.GetComponent<BallMovement> ();
	}

	void Update () {
		float translation = Input.GetAxis("HorizontalMovement") * speedMovement;
		translation *= Time.deltaTime;
		transform.Translate(translation, 0, 0);
		if (transform.position.x >= max_distance)
			transform.position = new Vector3 (max_distance, transform.position.y, 0);
		if (transform.position.x <= -max_distance)
			transform.position = new Vector3 (-max_distance, transform.position.y, 0);
		if (Input.GetAxis ("Throw") != 0.0f)
			m_movementBall.InitMovement ();
	}
}
