using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {
	
	public float speedMovement = 10.0f;
	public float angleDesviation = 10.0f;
	public float timeForEvolution = 45.0f;
	public float speedEvolution = 3.0f;
	private float origSpeed;
	private float m_elapsedEvolution = 0.0f;
	private Rigidbody2D rb2D;
	private bool initMovement = false;
	private bool m_fire = false;
	public float fireTime = 5.0f;
	private float m_currentFireTime = 0.0f;
	private AudioSource[] sounds;
	Animator anim;

	void Start () {
		origSpeed = speedMovement;
		anim = GetComponent<Animator>();
		rb2D = GetComponent<Rigidbody2D> ();
		sounds = GetComponents<AudioSource>();
	}

	void Update() {
		if (initMovement){
			m_elapsedEvolution += Time.deltaTime;
			if (m_elapsedEvolution >= timeForEvolution) {
				m_elapsedEvolution = 0;
				speedMovement += speedEvolution;
			}
		}
		if (m_fire) {
			m_currentFireTime -= Time.deltaTime;
			if(m_currentFireTime <= 0){
				anim.SetBool("isFire", false);
				m_fire = false;
			}
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
		speedMovement = origSpeed;
		rb2D.velocity = new Vector3 (0, 0, 0);
		initMovement = false;
		transform.eulerAngles = new Vector3 (0, 0, 0);
	}

	public void SetInitMovement(bool b) {
		initMovement = b;
	}

	public void SetFire( bool enable) {
		sounds [1].Play ();
		m_fire = enable;
		if (enable) {
			m_currentFireTime = fireTime;
			anim.SetBool("isFire", true);
		}

		
	}

	public bool GetFire() {
		return m_fire;
	}

	void OnCollisionEnter2D(Collision2D other) {
		sounds [0].Play ();
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
		sounds [1].Play ();
		speedMovement = speed;
	}
	
	public float GetSpeed() {
		return speedMovement;
	}
}
