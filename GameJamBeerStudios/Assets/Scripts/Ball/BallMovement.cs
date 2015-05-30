using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {
	
	public float speedMovement = 10.0f;
	private Rigidbody2D rb2D;
	private bool initMovement = false;
	private bool m_fire = false;
	public float fireTime = 5.0f;
	private float m_currentFireTime = 0;

	void Start () {
		rb2D = GetComponent<Rigidbody2D> ();
	}

	void Update() {
		if (m_fire) {
			m_currentFireTime -= Time.deltaTime;
			if(m_currentFireTime <= 0)
				m_fire = false;
		}
	}

	public void InitMovement(Vector3 angle) {
		if (!initMovement) {
			transform.eulerAngles = angle;
			initMovement = true;
			rb2D.AddForce (new Vector2(transform.up.x,transform.up.y) * speedMovement, ForceMode2D.Impulse);
		}
	}

	public void Reset()
	{
		rb2D.velocity = new Vector3 (0, 0, 0);
		initMovement = false;
		transform.eulerAngles = new Vector3 (0, 0, 0);
	}

	public void SetFire( bool enable) {
		m_fire = enable;
		if (enable)
			m_currentFireTime = fireTime;
	}

	public bool GetFire() {
		return m_fire;
	}
}
