using UnityEngine;
using System.Collections;

public class MovementCube : MonoBehaviour {


	public float speedMovement = 5.0f;
	public float max_distance = 10.0f;
	
	void Start () {
		GameObject ball = GameObject.FindGameObjectWithTag (Tags.ball);
	}

	void Update () {
		float direction = 0;
		if (Input.GetKey (KeyCode.RightArrow))
			direction = 1;
		if (Input.GetKey (KeyCode.LeftArrow))
			direction = -1;

		float translation = direction * speedMovement;
		translation *= Time.deltaTime;
		transform.Translate(translation, 0, 0);
		if (transform.position.x >= max_distance)
			transform.position = new Vector3 (max_distance, transform.position.y, 0);
		if (transform.position.x <= -max_distance)
			transform.position = new Vector3 (-max_distance, transform.position.y, 0);

	}
}
