using UnityEngine;
using System.Collections;

public class MovementCube : MonoBehaviour {

	public enum MovementType
	{
		Normal,
		Circular
	};

	public MovementType TypeMovement = MovementType.Normal;
	public float speedMovement = 5.0f;
	public float max_distance = 10.0f;

	public float radious = 5.0f;
	public float angularSpeed = 50.0f;
	
	private float angle = 0;

	void Start () {
		GameObject ball = GameObject.FindGameObjectWithTag (Tags.ball);
		angle = transform.rotation.eulerAngles.z;
	}

	void Update () {
		float direction = 0;
		if (Input.GetKey (KeyCode.RightArrow))
			direction = 1;
		if (Input.GetKey (KeyCode.LeftArrow))
			direction = -1;
		switch (TypeMovement) {
		case MovementType.Normal:
			float translation = direction * speedMovement;
			translation *= Time.deltaTime;
			transform.Translate(translation, 0, 0);
			if (transform.position.x >= max_distance)
				transform.position = new Vector3 (max_distance, transform.position.y, 0);
			if (transform.position.x <= -max_distance)
				transform.position = new Vector3 (-max_distance, transform.position.y, 0);
			break;
		case MovementType.Circular:
			float rot = direction * angularSpeed * Time.deltaTime;
			angle -= rot;
			
			//movement
			float x = Mathf.Sin(angle * Mathf.Deg2Rad) * radious;
			float y = -Mathf.Cos(angle * Mathf.Deg2Rad) * radious;
			transform.position = new Vector3 (x, y, 0);
			
			//rotation
			Quaternion quat = new Quaternion(0,0,0,0);
			quat.eulerAngles = new Vector3(0, 0, angle);
			transform.rotation = quat;
			break;
		}


	}
}
