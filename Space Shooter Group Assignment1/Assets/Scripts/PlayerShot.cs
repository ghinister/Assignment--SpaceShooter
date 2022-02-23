using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    [SerializeField] private float shotSpeed = 50f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position += Vector3.up * shotSpeed * Time.deltaTime;
    }

	private void OnBecameInvisible()
	{
        Destroy(this.gameObject);
	}
}
