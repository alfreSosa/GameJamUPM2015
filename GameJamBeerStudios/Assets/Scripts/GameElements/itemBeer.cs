using UnityEngine;
using System.Collections;

public class itemBeer : MonoBehaviour {

	public float speed = 1;

	private Vector3 vec0;
	private Vector3 vec1;

	// Use this for initialization
	void Start () {
		vec0 = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
		vec1 = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));
		Debug.Log ("vec0" + vec0.ToString());
		Debug.Log ("vec1" + vec1.ToString());
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += -transform.up * speed * Time.deltaTime;
					
	
		DestroyBoundaries ();
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == Tags.player) {
			DoFunction();
			Destroy (gameObject);
		}
		
	}
	void DestroyBoundaries() {
		if ((transform.position.x < vec0.x) || (transform.position.x > vec1.x) || (transform.position.y < vec0.y) || (transform.position.y > vec1.y))
			Destroy(gameObject);
	}

	void DoFunction() {
		//llamar a una funcion del player
	}
}
