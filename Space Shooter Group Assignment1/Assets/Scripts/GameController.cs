using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
	[SerializeField] private GameObject asteroid;
	[SerializeField] private GameObject gem;
	[SerializeField] private GameObject coin;
	[SerializeField] private Camera mainCamera;
	[SerializeField] private Text scoreText;
	[SerializeField] private TMP_Text scoreTMP;

	private int score = 0;
	private bool gameOver = false;

	Vector2 spawnMin;
	Vector2 spawnMax;
	
	private float asteroidSpawnDelay = 3;
	private float gemSpawnDelay = 10;
	private float coinSpawnDelay = 8;

	void Start()
	{
		if (mainCamera == null)
		{
			mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		}

		gameOver = false;
		SetSpawnPosition();
		StartCoroutine(Spawn(asteroid,asteroidSpawnDelay));
		StartCoroutine(Spawn(gem, gemSpawnDelay));
		StartCoroutine(Spawn(coin, coinSpawnDelay));
		UpdateScoreText();
	}

	void Update()
	{

	}

	void SetSpawnPosition()
	{
		spawnMin = mainCamera.ViewportToWorldPoint(new Vector2(0, 1));
		spawnMax = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));


	}

	IEnumerator Spawn(GameObject _asteroid, float _asteroidSpawnDalay)
	{
		while (!gameOver)
		{
            Vector2 spawnPosition = new Vector2(Random.Range(spawnMin.x, spawnMax.x), 3*spawnMax.y);
            Quaternion spawnRotation = Quaternion.identity;
			Instantiate(_asteroid, spawnPosition, spawnRotation);
			yield return new WaitForSeconds(_asteroidSpawnDalay);
		}

		yield return null;
	}

	public void UpdateScore(int change)
	{
		score += change;
		UpdateScoreText();
	}

	void UpdateScoreText()
	{
		scoreText.text = "Score : " + score;
		scoreTMP.text = "Score : " + score;
	}
}
