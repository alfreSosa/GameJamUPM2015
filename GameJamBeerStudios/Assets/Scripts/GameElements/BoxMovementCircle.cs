using UnityEngine;
using System.Collections;

public class BoxMovementCircle : MonoBehaviour {

	public float radious = 5.0f;
	public float angularSpeed = 50.0f;
	public bool toRight = true;

	private float m_direction;
	private float m_angle = 0;
	private Vector3 m_center;

	// Use this for initialization
	void Start () {
		if (toRight)
			m_direction = -1;
		else
			m_direction = 1;
		m_angle = transform.rotation.eulerAngles.z;
		m_center = transform.position + transform.up * radious;
	}
	
	// Update is called once per frame
	void Update () {
		float rot = m_direction * angularSpeed * Time.deltaTime;
		m_angle -= rot;
		
		//movement
		float x = Mathf.Sin(m_angle * Mathf.Deg2Rad) * radious;
		float y = -Mathf.Cos(m_angle * Mathf.Deg2Rad) * radious;
		transform.position = m_center + new Vector3 (x, y, 0);
		
		//rotation
		Quaternion quat = new Quaternion(0,0,0,0);
		quat.eulerAngles = new Vector3(0, 0, m_angle);
		transform.rotation = quat;
	}
}
