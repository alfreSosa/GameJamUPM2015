using UnityEngine;
using System.Collections;

public class BoxMovementUp : MonoBehaviour {

	Animator anim;

	public float speed = 5.0f;
	public float distance = 3.0f;
	
	private float m_direction = 1;
	private float m_currentDistance = 0;
	private Vector3 m_initialPosition; 
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		m_initialPosition = transform.position;
		anim.SetFloat("Direction", m_direction);
	}
	
	// Update is called once per frame
	void Update () {
		m_currentDistance += m_direction * speed * Time.deltaTime;
		if (m_currentDistance > distance) {
			m_currentDistance = distance;
			m_direction *= -1;
		} else if (m_currentDistance < 0) {
			m_currentDistance = 0;
			m_direction *= -1;

		}
		anim.SetFloat("Direction", m_direction);
		transform.position = m_initialPosition + transform.up * m_currentDistance;
	}
}
