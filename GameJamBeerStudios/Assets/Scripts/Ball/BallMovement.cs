using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {
	
	public float speedMovement = 10.0f;
	public float angleDesviation = 10;
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

	public void InitMovement(Vector3 angle, GameObject p) {
		if (!initMovement) {
			if (p)
				transform.rotation = p.transform.rotation;
			transform.eulerAngles += angle;
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

	public void SetInitMovement(bool b) {
		initMovement = b;
	}
	public void SetFire( bool enable) {
		m_fire = enable;
		if (enable)
			m_currentFireTime = fireTime;
	}

	public bool GetFire() {
		return m_fire;
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag != Tags.item) {
			float angle = (Random.Range(-1, 1) >= 0) ? angleDesviation : -angleDesviation;
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + angle);
			Debug.Log(transform.eulerAngles);
		}
		if (other.gameObject.tag == Tags.player) {
			if (other.gameObject.GetComponent<ThrowBall>().GetMagnetic())
				other.gameObject.GetComponent<ThrowBall>().ResetMagnetic(transform.gameObject);
		}
	}

	public void SetSpeed(float speed) {
		speedMovement = speed;
	}
	
	public float GetSpeed() {
		return speedMovement;
	}
}
