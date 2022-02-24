using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 5f;

    [SerializeField] private Camera mainCamera;

    [SerializeField] private SpriteRenderer[] sprites;

	private void Start()
	{
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
	// Update is called once per frame
	void Update()
    {
        //find the lowest y value in world space
        float minY = mainCamera.ViewportToWorldPoint(new Vector2(0, 0)).y;

        foreach(SpriteRenderer sr in sprites)
		{
            sr.transform.position += Vector3.down * scrollSpeed * Time.deltaTime;

            if(sr.bounds.max.y < minY)
			{
                Vector2 position = sr.transform.position;

                position.y = position.y + (sprites.Length * sr.bounds.size.y);
                sr.transform.position = position;

			}
		}
    }
}
