using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] private GameController gameController;

    private int itemSpeed = 30;
    private int gemScore = 200;

    // Start is called before the first frame update
    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("GameController");
        if (go != null)
        {
            gameController = go.GetComponent<GameController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * itemSpeed * Time.deltaTime;
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
            gameController.UpdateScore(gemScore);
            Destroy(this.gameObject);
		}
	}

	private void OnBecameInvisible()
	{
		Destroy(this.gameObject);
	}
}

