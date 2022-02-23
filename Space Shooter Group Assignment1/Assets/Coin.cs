using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameController gameController;

    private int itemSpeed = 15;
    private int coinScore = 50;

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
            gameController.UpdateScore(coinScore);
            Destroy(this.gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
