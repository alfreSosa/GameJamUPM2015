using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public enum LevelType
	{
		Cube,
		Circle,
		Triangle
	};

	public LevelType TypeLevel = LevelType.Cube;
	public float heightPlayer = -4;
	public float lifes = 3;
	private GameObject[] balls;
	private GameObject[] players;

	void Start () {
		balls = GameObject.FindGameObjectsWithTag (Tags.ball);
		players = GameObject.FindGameObjectsWithTag (Tags.player);
		/*player.transform.position = new Vector3 (0, heightPlayer, 0);
		ball.transform.position = new Vector3 (0, heightPlayer + 0.5f, 0);
		Rigidbody2D rb2D = ball.GetComponent<Rigidbody2D> ();
		rb2D.velocity = new Vector3(0,0,0);*/
	}
	
	void Update () {
		balls = GameObject.FindGameObjectsWithTag (Tags.ball);
		switch (TypeLevel) {
		case LevelType.Cube:
			if (balls.Length == 1){
				if (balls[0].transform.position.y < players[0].transform.position.y) {
					LoseLife ();
					ResetLevel();
				}
			}
			break;
		case LevelType.Circle:
			break;
		case LevelType.Triangle:
			break;
		}

		
	}
	
	public void LoseLife() {
		lifes--;
	}

	public void AddLife() {
		if (lifes < 4)
			lifes++;
	}

	public void ResetLevel() {

	}
}
