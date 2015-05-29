using UnityEngine;
using System.Collections;

public class MovementCube : MonoBehaviour {


	public float speedMovement = 50.0f;

	void Start () {
	}

	void Update () {
		float translation = Input.GetAxis("HorizontalMovement") * speedMovement;
		translation *= Time.deltaTime;
		transform.Translate(translation, 0, 0);
	}
}
