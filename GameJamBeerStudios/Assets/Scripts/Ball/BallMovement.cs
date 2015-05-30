using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {
	
	public float speedMovement = 10.0f;
	public float angleDesviation = 10.0f;
	private Rigidbody2D rb2D;
	private bool initMovement = false;
	private bool m_fire = false;
	public float fireTime = 5.0f;
	private float m_currentFireTime = 0.0f;

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

	public void Reset()	{
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
			Vector3 vel = rb2D.velocity;
			rb2D.velocity = new Vector3(0,0,0);
			float tan = vel.y/vel.x;
			float angle = Mathf.Atan(tan) * Mathf.Rad2Deg;
			transform.eulerAngles = new Vector3 (0, 0, angle);
			float d = Vector3.Dot(vel, transform.up);
			while (d < 0.01){
				transform.eulerAngles += new Vector3 (0, 0, 90);
				d = Vector3.Dot(vel, transform.up);
			}
			float value = Random.Range(-angleDesviation, angleDesviation);
			transform.eulerAngles += new Vector3 (0, 0, value);
			rb2D.AddForce (new Vector2(transform.up.x,transform.up.y) * speedMovement, ForceMode2D.Impulse);
		}
		if (other.gameObject.tag == Tags.player) {
			ThrowBall thow = other.gameObject.GetComponent<ThrowBall>();
			if (thow.GetMagnetic() && !thow.GetPossesed())
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
