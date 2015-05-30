using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public enum LevelType
	{
		Cube,
		Circle,
		Triangle,
		Boss
	};

	public LevelType TypeLevel = LevelType.Cube;
	public int lifes = 3;
	public float RadiousLevel = 5.0f;

	public Sprite[] imgPlayer;
	private GameObject[] balls;
	private GameObject[] players;

	private bool m_magnetic = false;
	private bool m_fireBall = false;
	private bool m_beer = false;
	private bool m_life = false;
	private bool m_lostSpeed = false;
	private bool m_gainSpeed = false;
	private bool m_triangleGameOver = false;
	private GameObject[] boxes;
	private int numberBricks = 1;
	private bool init = false;

	void Start() {
		balls = GameObject.FindGameObjectsWithTag (Tags.ball);
		players = GameObject.FindGameObjectsWithTag (Tags.player);
	}
	
	void Update () {
		if (!init) {
			ResetLevel();
			init = true;
		}

		balls = GameObject.FindGameObjectsWithTag (Tags.ball);
		switch (TypeLevel) {
		case LevelType.Cube:
			if (balls.Length == 1){
				if (balls[0].transform.position.y < players[0].transform.position.y) {
					LoseLife ();
					ResetLevel();
					ResetItem();
					int size = players.Length;
					for (int i = 0; i < size; i++)
						players [i].GetComponent<ThrowBall> ().SetMagnetic(false);
				}
			}
			if (numberBricks == 0) {
				Victory();
			}
			break;
		case LevelType.Circle:
			if (balls.Length == 1){
				float distanceBall = Mathf.Sqrt(balls[0].transform.position.x * balls[0].transform.position.x + balls[0].transform.position.y * balls[0].transform.position.y);
				if (distanceBall > RadiousLevel) {
					LoseLife ();
					ResetLevel();
					ResetItem();
					int size = players.Length;
					for (int i = 0; i < size; i++)
						players [i].GetComponent<ThrowBall> ().SetMagnetic(false);
				}
			}
			if (numberBricks == 0)
				Victory();
			break;
		case LevelType.Triangle:
			if (m_triangleGameOver) {
				LoseLife ();
				ResetLevel();
				ResetItem();
				m_triangleGameOver = false;
				int size = players.Length;
				for (int i = 0; i < size; i++)
					players [i].GetComponent<ThrowBall> ().SetMagnetic(false);
			}
			if (numberBricks == 0)
				Victory();
			break;
		case LevelType.Boss:
			if (balls.Length == 1){
				if (balls[0].transform.position.y < players[0].transform.position.y) {
					LoseLife ();
					ResetLevel();
					ResetItem();
					int size = players.Length;
					for (int i = 0; i < size; i++)
						players [i].GetComponent<ThrowBall> ().SetMagnetic(false);
				}
			}
			break;
		}
	}
	
	public void LoseLife() {
		lifes--;
		changeSizeplayer ();
	}

	public void GainLife() {
		lifes++;
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
			Defeat();
			break;
		case 1:
			for (int i = 0; i < size; i++){
				players[i].transform.GetComponent<SpriteRenderer>().sprite = imgPlayer[0];
				Destroy(players[i].GetComponent<PolygonCollider2D>());
				players[i].AddComponent<PolygonCollider2D>();
			}
				//players [i].transform.localScale = new Vector3(0.33f, 1.0f, 1.0f);
			break;
		case 2:
			for (int i = 0; i < size; i++){
				players[i].transform.GetComponent<SpriteRenderer>().sprite = imgPlayer[1];
				Destroy(players[i].GetComponent<PolygonCollider2D>());
				players[i].AddComponent<PolygonCollider2D>();
			}
				//players [i].transform.localScale = new Vector3(0.66f, 1.0f, 1.0f);
			break;
		case 3:
			for (int i = 0; i < size; i++){
				players[i].transform.GetComponent<SpriteRenderer>().sprite = imgPlayer[2];
				Destroy(players[i].GetComponent<PolygonCollider2D>());
				players[i].AddComponent<PolygonCollider2D>();
			}
			break;
		case 4:
			for (int i = 0; i < size; i++){
				players[i].transform.GetComponent<SpriteRenderer>().sprite = imgPlayer[3];
				Destroy(players[i].GetComponent<PolygonCollider2D>());
				players[i].AddComponent<PolygonCollider2D>();
			}
			break;
		}
	}

	public void ResetLevel() {
		int size = players.Length;
		for (int i = 0; i < size; i++)
			players [i].GetComponent<ThrowBall> ().Reset ();

		balls [0].GetComponent<BallMovement> ().Reset ();

		int id = -1;
		float min = 10000000;
		for (int i = 0; i < size; i++) {
			Vector3 vec = players [i].transform.position - balls[0].transform.position;
			float dis = vec.x * vec.x + vec.y * vec.y;
			if (dis < min)  {
				id = i;
				min = dis;
			}
		}
		players [id].GetComponent<ThrowBall> ().possesedBall = true;

	}

	public LevelType GetLevelType() {
		return TypeLevel;
	}

	void ResetItem(){
		m_magnetic = false;
		m_fireBall = false;
		m_beer = false;
		m_life = false;
		m_gainSpeed = false;
		m_lostSpeed = false;
	}

	public void SetMagneticItem(){
		m_magnetic = true;
	}

	public bool GetMagneticItem(){
		return m_magnetic;
	}

	public void SetFireBallItem(){
		m_fireBall = true;
	}
	
	public bool GetFireBallItem(){
		return m_fireBall;
	}

	public void SetBeerItem(){
		m_beer = true;
	}
	
	public bool GetBeerItem(){
		return m_beer;
	}

	public void SetLifeItem(){
		m_life = true;
	}
	
	public bool GetLifeItem(){
		return m_life;
	}

	public void SetLostSpeedItem(){
		m_lostSpeed = true;
	}
	
	public bool GetLostSpeedItem(){
		return m_lostSpeed;
	}

	public void SetGainSpeedItem(){
		m_gainSpeed = true;
	}
	
	public bool GetGainSpeedItem(){
		return m_gainSpeed;
	}

	public void DestroyBrick() {
		numberBricks = 0;
		boxes = GameObject.FindGameObjectsWithTag (Tags.box);
		int sizeBoxes = boxes.Length;
		for (int j = 0; j < sizeBoxes; j++) {
			boxScript s = boxes [j].GetComponent<boxScript>();
			if (s)
				if (s.breakable)
					numberBricks++;
		}
		numberBricks--;
	}

	public void RemoveBall(GameObject b) {
		if (b.tag == Tags.ball) {
			if (balls.Length > 1)
				Destroy(b);
			else
				m_triangleGameOver = true;
		}
	}

	public void Victory() {
		GameObject fade = GameObject.FindGameObjectWithTag (Tags.fade);
		fade.GetComponent<ScreenFader> ().End_Game (true);
	}

	void Defeat() {
		GameObject fade = GameObject.FindGameObjectWithTag (Tags.fade);
		fade.GetComponent<ScreenFader> ().End_Game (false);

	}
}
