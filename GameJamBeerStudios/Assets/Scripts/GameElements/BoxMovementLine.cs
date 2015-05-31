using UnityEngine;
using System.Collections;

public class BoxMovementLine : MonoBehaviour {

	public float speed = 5.0f;
	public float distance = 3.0f;

	private float m_direction = 1;
	private float m_currentDistance = 0;
	private Vector3 m_initialPosition; 

	// Use this for initialization
	void Start () {
		m_initialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		m_currentDistance += m_direction * speed * Time.deltaTime;
		if (m_currentDistance > distance) {
			m_currentDistance = distance;
			m_direction *= -1;
			transform.eulerAngles = new Vector3(0, 180, 0);
		} else if (m_currentDistance < 0) {
			m_currentDistance = 0;
			m_direction *= -1;
			transform.eulerAngles = new Vector3(0, 0, 0);
			
		}
		transform.position += transform.right * speed * Time.deltaTime;
	}
}
