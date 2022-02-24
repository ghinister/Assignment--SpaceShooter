using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float asteroidSpeedMin = 20;
    [SerializeField] private float asteroidSpeedMax = 100;
    [SerializeField] private int asteroidScore = 100;
    private float asteroidMoveSpeed;
    private float asteroidRotateSpeed;
    private Vector2 directionToPlayer;

    [SerializeField] private GameController gameController;


    
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            directionToPlayer = player.position - transform.position;
            directionToPlayer.Normalize();
        }
		else
		{
            directionToPlayer = Vector2.down;
		}

        asteroidMoveSpeed = Random.Range(asteroidSpeedMin, asteroidSpeedMax);
        asteroidRotateSpeed = asteroidMoveSpeed * 10;

        GameObject go = GameObject.FindGameObjectWithTag("GameController");
        if(go != null)
		{
            gameController = go.GetComponent<GameController>();
		}
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, asteroidRotateSpeed * Time.deltaTime, Space.World);
        transform.position += (Vector3)directionToPlayer * asteroidMoveSpeed * Time.deltaTime;
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
            Destroy(collision.gameObject);
		}
		else
		{
            gameController.UpdateScore(asteroidScore);
            Destroy(this.gameObject);
		}
	}

	private void OnBecameInvisible()
	{
        Destroy(this.gameObject);
	}
}
