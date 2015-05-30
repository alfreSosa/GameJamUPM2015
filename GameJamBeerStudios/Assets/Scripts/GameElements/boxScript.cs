using UnityEngine;
using System.Collections;

public class boxScript : MonoBehaviour {

	public int life = 1;
	public bool hasDrop = false;
	public bool breakable = true;

	public GameObject[] items;
	public int[] percentage;
	
	// Use this for initialization
	void Start () {

	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		if (breakable) {
			if (collision.gameObject.tag == Tags.ball) {
				if(collision.gameObject.GetComponent<BallMovement> ().GetFire ())
					life = 0;
				else
					life--;
				if (life <= 0) {
						GameObject gameManager = GameObject.FindGameObjectWithTag (Tags.gameManager);
					
					if (hasDrop) {
						bool success = false;

						while(!success){
						float valueR = Random.Range(0, 100);

						if(valueR < percentage[0]){  //multiball
							GameObject[] balls = GameObject.FindGameObjectsWithTag (Tags.ball);
							int size = balls.Length;
							if(size == 1){
								success = true;
								Instantiate (items [0], transform.position, transform.rotation);
							}
						}
						else if(valueR < percentage[1])  //magnetic
							if(!gameManager.GetComponent<GameManager> ().GetMagneticItem()){
								gameManager.GetComponent<GameManager> ().SetMagneticItem();
								success = true;
								Instantiate (items [1], transform.position, transform.rotation);
							}
						else if(valueR < percentage[2])  //fireball
							if(!gameManager.GetComponent<GameManager> ().GetFireBallItem()){
								gameManager.GetComponent<GameManager> ().SetFireBallItem();
								success = true;
								Instantiate (items [2], transform.position, transform.rotation);
							}
						else if(valueR < percentage[3])  //beer
							if(!gameManager.GetComponent<GameManager> ().GetBeerItem()){
								gameManager.GetComponent<GameManager> ().SetBeerItem();
								success = true;
								Instantiate (items [3], transform.position, transform.rotation);
							}
						else if(valueR < percentage[4])  //life
							if(!gameManager.GetComponent<GameManager> ().GetLifeItem()){
								gameManager.GetComponent<GameManager> ().SetLifeItem();
								success = true;
								Instantiate (items [4], transform.position, transform.rotation);
							}
						else if(valueR < percentage[5])  //lostSpeedBall
							if(!gameManager.GetComponent<GameManager> ().GetLostSpeedItem()){
								gameManager.GetComponent<GameManager> ().SetLostSpeedItem();
								success = true;
								Instantiate (items [5], transform.position, transform.rotation);
							}
						else if(valueR < percentage[6])  //gainSpeedBall
							if(!gameManager.GetComponent<GameManager> ().GetGainSpeedItem()){
								gameManager.GetComponent<GameManager> ().SetGainSpeedItem();
								success = true;
								Instantiate (items [6], transform.position, transform.rotation);
							}
						}
						
					}
					gameManager.GetComponent<GameManager> ().DestroyBrick();
					Destroy (gameObject);
				}
			}
		}
	}
}
