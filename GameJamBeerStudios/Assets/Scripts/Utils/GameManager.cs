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
	public int lifes = 3;
	private GameObject[] balls;
	private GameObject[] players;

	void Start () {
		balls = GameObject.FindGameObjectsWithTag (Tags.ball);
		players = GameObject.FindGameObjectsWithTag (Tags.player);
		int size = players.Length;
		for (int i = 0; i < size; i++)
			players [i].GetComponent<ThrowBall> ().Reset ();
		
		balls [0].GetComponent<BallMovement> ().Reset ();
	}
	
	void Update () {
		balls = GameObject.FindGameObjectsWithTag (Tags.ball);
		switch (TypeLevel) {
		case LevelType.Cube:
			if (balls.Length == 1){
				if (balls[0].transform.position.y < players[0].transform.position.y) {
					LoseLife ();
					ResetLevel();
					int size = players.Length;
					for (int i = 0; i < size; i++)
						players [i].GetComponent<ThrowBall> ().SetMagnetic(false);
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
		changeSizeplayer ();
	}

	public void AddLife() {
		if (lifes < 4) {
			lifes++;
			changeSizeplayer ();
		}
	}

	void changeSizeplayer () {
		int size = players.Length;
		switch (lifes) {
		case 0:
			//derrota
			break;
		case 1:
			for (int i = 0; i < size; i++)
				players [i].transform.localScale = new Vector3(0.33f, 1.0f, 1.0f);
			break;
		case 2:
			for (int i = 0; i < size; i++)
				players [i].transform.localScale = new Vector3(0.66f, 1.0f, 1.0f);
			break;
		case 3:
			for (int i = 0; i < size; i++)
				players [i].transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
			break;
		case 4:
			for (int i = 0; i < size; i++)
				players [i].transform.localScale = new Vector3(1.33f, 1.0f, 1.0f);
			break;
		}
	}

	public void ResetLevel() {
		int size = players.Length;
		for (int i = 0; i < size; i++)
			players [i].GetComponent<ThrowBall> ().Reset ();

		balls [0].GetComponent<BallMovement> ().Reset ();
	}

	public LevelType GetLevelType() {
		return TypeLevel;
	}
}
