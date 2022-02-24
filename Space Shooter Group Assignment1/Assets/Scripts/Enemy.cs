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

            // Find an angle between player and enemy.
            // Default Mathf.Atan2 return a radian coordinate angle.
            // We need to multiply with Mathf.Rad2Deg to get the degree coordinate so it usable.
            float _angle = Mathf.Atan2(directionToPlayer.y, 0 - directionToPlayer.x) * Mathf.Rad2Deg;

            // Use Quaternion.AngleAxis to rotate axis of transform.
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
