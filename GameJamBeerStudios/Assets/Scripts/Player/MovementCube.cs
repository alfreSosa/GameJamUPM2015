﻿using UnityEngine;
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

	private float m_currentDistance = 0;

	public float DrunkDuration = 5.0f;

	private float angle = 0;
	private float drunkDir = 1;
	private float drunkElapsed = 0.0f;
	private bool isDrunk = false;

	private bool m_lock = false;
	private AudioSource[] sounds;

	private Vector3 m_initialPosition;
	
	void Start () {
		sounds = GetComponents<AudioSource>();
		angle = transform.rotation.eulerAngles.z;
		m_initialPosition = transform.position;
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
		if (Input.GetKey (KeyCode.RightArrow) && !m_lock)
			direction = 1 * drunkDir;
		if (Input.GetKey (KeyCode.LeftArrow) && !m_lock)
			direction = -1 * drunkDir;

		switch (TypeMovement) {
		case MovementType.Normal:
			float translation = direction * speedMovement;
			translation *= Time.deltaTime;
			m_currentDistance += translation;
			
			if (m_currentDistance >= max_distance) {
				m_currentDistance = max_distance;
			} else if (m_currentDistance <= -max_distance) {
				m_currentDistance = -max_distance;
			}
			
			if (m_currentDistance < max_distance && m_currentDistance > -max_distance)
				transform.position += transform.right * translation;
			break;
		case MovementType.Circular:
			float rot = -direction * angularSpeed * Time.deltaTime;
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
		sounds [0].Play ();
		drunkDir = -1;
		drunkElapsed = 0.0f;
		isDrunk = true;
	}

	public void ResetMovement() {
		m_currentDistance = 0;
		transform.position = m_initialPosition;
	}

	public void LockInput(){
		m_lock = true;
	}
}
