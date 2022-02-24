using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float asteroidSpeedMin = 20;
    [SerializeField] private float asteroidSpeedMax = 100;
    [SerializeField] private int asteroidScore = 100;
    private float asteroidMoveSpeed;
    private float asteroidRotateSpeed;
    private Vector2 directionToPlayer;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            directionToPlayer = player.position - transform.position;
            directionToPlayer.Normalize();

            float _angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x)*Mathf.Rad2Deg;
            _angle = (_angle + 90);
            transform.rotation = Quaternion.AngleAxis(_angle, Vector3.forward);

        }
        else
        {
            directionToPlayer = Vector2.down;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
