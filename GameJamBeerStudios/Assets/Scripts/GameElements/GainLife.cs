using UnityEngine;
using System.Collections;

public class GainLife : MonoBehaviour {
	public float speed = 1.0f;
	
	private Vector3 vec0;
	private Vector3 vec1;
	
	// Use this for initialization
	void Start () {
		vec0 = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
		vec1 = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));
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
		GameObject gameManager = GameObject.FindGameObjectWithTag (Tags.gameManager);
		gameManager.GetComponent<GameManager> ().GainLife();
	}
}