using UnityEngine;
using System.Collections;

public class bossMovement : MonoBehaviour {
	public int life = 6;
	public int secondPhaseLife = 2;
	public float distance = 5;
	public float speed = 5.0f;

	private bool m_secondPhase = false;
	private Vector3 m_initialPosition;
	private Vector3 m_initialVector;
	private float m_currentDistance = 0.0f;
	private int m_count = 1;

	public GameObject minion;
	public float timeToMinion = 1.0f;
	private float m_countMinion = 0.0f;

	// Use this for initialization
	void Start () {
		m_initialPosition = transform.position;
		m_initialVector = transform.right;
	}
	
	// Update is called once per frame
	void Update () {
		phase1 ();
		if(m_secondPhase)
			phase2 ();
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == Tags.ball) {
			life--;
			if(life <= secondPhaseLife)
				m_secondPhase = true;
			if (life <= 0) {
				GameObject gameManager = GameObject.FindGameObjectWithTag(Tags.gameManager);
				GameManager manager = gameManager.GetComponent<GameManager>();
				manager.Victory();
				Destroy (gameObject);
			}
		}
	}

	void phase1(){
		m_currentDistance += speed * Time.deltaTime;
		if (m_currentDistance > distance) {
			m_currentDistance = distance;
		} 
		transform.position = m_initialPosition + m_initialVector * m_currentDistance;
		if (m_currentDistance == distance) {
			m_currentDistance = 0;
			transform.eulerAngles += new Vector3(0.0f, 0.0f, m_count * 120.0f);
			m_initialVector = transform.right;
			transform.eulerAngles -= new Vector3(0.0f, 0.0f, m_count * 120.0f);
			m_count++;
			if(m_count >= 3)
				m_count = 0;
			m_initialPosition = transform.position;
		}
	}

	void phase2(){
		m_countMinion += Time.deltaTime;
		if (m_countMinion > timeToMinion) {
			m_countMinion = 0;
			Instantiate (minion, transform.position, transform.rotation);
		} 
	}
}
