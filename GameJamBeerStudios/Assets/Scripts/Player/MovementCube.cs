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

	public float DrunkDuration = 5.0f;

	private float angle = 0;
	private float drunkDir = 1;
	private float drunkElapsed = 0.0f;
	private bool isDrunk = false;
	void Start () {
		GameObject ball = GameObject.FindGameObjectWithTag (Tags.ball);
		angle = transform.rotation.eulerAngles.z;
	}

	void Update () {
		if (isDrunk) {
			drunkElapsed += Time.deltaTime;
			if (drunkElapsed >= DrunkDuration) {
				drunkDir = 1;
				isDrunk = false;
			}
		}
		float direction = 0;
		if (Input.GetKey (KeyCode.RightArrow))
			direction = 1 * drunkDir;
		if (Input.GetKey (KeyCode.LeftArrow))
			direction = -1 * drunkDir;
		switch (TypeMovement) {
		case MovementType.Normal:
			float translation = direction * speedMovement;
			translation *= Time.deltaTime;
			transform.Translate(transform.right * translation);
			float dot = Vector3.Dot(transform.right, transform.position);
			float dotUp = Vector3.Dot(transform.up, transform.position);
			if (dot >= max_distance)
				transform.position = transform.right * max_distance + transform.up * dotUp;
			if (dot <= -max_distance)
				transform.position = transform.right * -max_distance + transform.up * dotUp;
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

	public void GetDrunk() {
		drunkDir = -1;
		drunkElapsed = 0.0f;
		isDrunk = true;
	}

}
