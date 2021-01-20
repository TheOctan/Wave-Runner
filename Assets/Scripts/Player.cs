using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
	[Header("Properties")]
	public float xSpeed = 3;
	public float ySpeed = 30;

	[Header("Objects")]
	public GameObject deadEffect;

	private GameManager gameManager;

	private Rigidbody2D rigidbody2d;
	private float angle = 0;
	private bool isDead;

	private void Awake()
	{
		rigidbody2d = GetComponent<Rigidbody2D>();
		gameManager = FindObjectOfType<GameManager>();
	}

	private void FixedUpdate()
	{
		if (isDead) return;

		MovePlayer();
		GetInput();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Obstacle"))
		{
			Dead();
		}
	}

	private void MovePlayer()
	{
		Vector2 pos = transform.position;
		pos.x = Mathf.Cos(angle) * 3;

		transform.position = pos;
		angle += Time.fixedDeltaTime * xSpeed;
	}

	private void GetInput()
	{
		if (Input.touchCount > 0)
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

	private void Dead()
	{
		isDead = true;

		EmitDeadEffect();
		StopPlayer();
		gameManager.GameOver();
	}

	private void EmitDeadEffect()
	{
		deadEffect.transform.position = transform.position;
		var particleEffrct = deadEffect.GetComponentInChildren<ParticleSystem>();
		particleEffrct.Play();
	}

	private void StopPlayer()
	{
		rigidbody2d.velocity = Vector2.zero;
		rigidbody2d.isKinematic = true;
	}
}
