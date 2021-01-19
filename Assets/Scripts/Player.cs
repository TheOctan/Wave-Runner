using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float xSpeed = 3;
    public float ySpeed = 30;

    private Rigidbody2D rigidbody2d;
    private float angle = 0;

	private void Awake()
	{
        rigidbody2d = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
        MovePlayer();
        GetInput();
    }

    private void MovePlayer()
	{
        Vector2 pos = transform.position;
        pos.x = Mathf.Cos(angle) * 3;
        //pos.y = 0;
        transform.position = pos;
        angle += Time.deltaTime * xSpeed;
	}

    private void GetInput()
	{
        if(Input.touchCount > 0)
		{
            var touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Stationary)
			{
                rigidbody2d.AddForce(new Vector2(0, ySpeed));
			}
        }
		else
		{
			if (rigidbody2d.velocity.y > 0)
			{
                rigidbody2d.AddForce(new Vector2(0, -ySpeed));
			}
			else
			{
                rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, 0);
			}
        }
    }
}
