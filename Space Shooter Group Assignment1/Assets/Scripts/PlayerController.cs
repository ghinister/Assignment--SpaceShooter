using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform frontGun;
    [SerializeField] private GameObject playerShot;

    private Vector2 lowerLeft; //0.0
    private Vector2 upperRight; //1.1

    [SerializeField]private float Speed = 50f;
    private Vector2 movementNewInput;

    void CreateBoundary()
	{
        lowerLeft = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        upperRight = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));

        Vector2 extents = spriteRenderer.bounds.extents;
        lowerLeft = lowerLeft + extents;
        upperRight = upperRight + extents;
    }
    Vector3 CheckBoundary(Vector3 pos)
	{
        pos.x = Mathf.Clamp(pos.x, lowerLeft.x, upperRight.x);
        pos.y = Mathf.Clamp(pos.y, lowerLeft.y, upperRight.y);
        return pos;
    }

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        }

        CreateBoundary();
        
    }

    void Update()
    {
        //Move();
        MoveNewInput();
        
    }

	/*private void Move()
	{
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector2 moveVector = new Vector2(moveHorizontal, moveVertical);
        moveVector.Normalize();
        //Debug.Log(moveVector);
        transform.position = transform.position + (Vector3)moveVector * Speed * Time.deltaTime;
    }*/

    private void MoveNewInput()
	{
        transform.position += (Vector3)movementNewInput * Speed * Time.deltaTime;
        transform.position = CheckBoundary(transform.position);
    }


    private void OnMove(InputValue moveValue)
	{
        movementNewInput = moveValue.Get<Vector2>();
        CreateBoundary();
    }

    private void OnFire(InputValue moveValue)
	{
        Instantiate(playerShot,frontGun.position, frontGun.rotation);
	}
}
