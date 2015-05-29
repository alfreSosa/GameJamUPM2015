using UnityEngine;
using System.Collections;

public class MovementCircular : MonoBehaviour {

	public float radious = 200.0f;
	public float angularSpeed = 50.0f;

	private float angle = 0;

	// Use this for initialization
	void Start () {
		angle = transform.rotation.eulerAngles.z + 180;
		Debug.Log (angle);
	}
	
	// Update is called once per frame
	void Update () {
		float direction = 0;
		if (Input.GetAxis ("HorizontalMovement") > 0)
			direction = 1;
		if (Input.GetAxis ("HorizontalMovement") < 0)
			direction = -1;

		float rot = direction * angularSpeed * Time.deltaTime;
		angle -= rot;

		//movement
		float x = Mathf.Sin(angle * Mathf.Deg2Rad) * radious;
		float y = Mathf.Cos(angle * Mathf.Deg2Rad) * radious;
		transform.position = new Vector3 (x, y, 0);

		//rotation
		Quaternion quat = new Quaternion(0,0,0,0);
		quat.eulerAngles = new Vector3(0, 0, -angle);
		transform.rotation = quat;
	}
}
