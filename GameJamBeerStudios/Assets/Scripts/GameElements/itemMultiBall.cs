using UnityEngine;
using System.Collections;

public class itemMultiBall : MonoBehaviour {
	public float speed = 1;
	public int BallsNumber = 3;
	public float BallsSpeed = 5;
	public float AngleSeparation = 45;
	private Vector3 vec0;
	private Vector3 vec1;

	public GameObject ball;
	// Use this for initialization
	void Start () {
		vec0 = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
		vec1 = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));
		//Debug.Log ("vec0" + vec0.ToString());
		//Debug.Log ("vec1" + vec1.ToString());
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += -transform.up * speed * Time.deltaTime;
		
		
		DestroyBoundaries ();
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == Tags.player) {
			DoFunction();
			Destroy (gameObject);
		}
		
	}
	void DestroyBoundaries() {
		if ((transform.position.x < vec0.x) || (transform.position.x > vec1.x) || (transform.position.y < vec0.y) || (transform.position.y > vec1.y))
			Destroy(gameObject);
	}
	
	void DoFunction() {
		GameObject bola = GameObject.FindGameObjectWithTag (Tags.ball);
		Vector3 position = bola.transform.position;
		Vector3 euler = bola.transform.localEulerAngles;
		for (int i = 0; i < BallsNumber; i++) {
			euler += new Vector3(0,0, AngleSeparation);
			Quaternion quat = new Quaternion(0,0,0,0);
			quat.eulerAngles = new Vector3(0, 0, euler.z);
			GameObject auxBall = Instantiate (ball, position, quat) as GameObject;
			auxBall.transform.position = position + auxBall.transform.up * 0.1f;
			auxBall.GetComponent<Rigidbody2D>().AddForce (new Vector2(auxBall.transform.up.x,auxBall.transform.up.y) * BallsSpeed, ForceMode2D.Impulse);
			auxBall.GetComponent<BallMovement>().SetInitMovement(true);
		}
	}
}
