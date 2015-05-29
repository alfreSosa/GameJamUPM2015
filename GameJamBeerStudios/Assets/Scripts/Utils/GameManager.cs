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
	public float lifes = 3;
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
		Debug.Log (lifes);
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
		int size = players.Length;
		for (int i = 0; i < size; i++)
			players [i].GetComponent<ThrowBall> ().Reset ();

		balls [0].GetComponent<BallMovement> ().Reset ();
	}

	public LevelType GetLevelType() {
		return TypeLevel;
	}
}
