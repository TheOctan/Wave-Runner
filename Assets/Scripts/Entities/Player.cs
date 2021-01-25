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
	public GameObject itemEffect;

	private GameEventHandler gameEventHandler;
	private Rigidbody2D rigidbody2d;
	private Camera mainCamera;

	private float angle = 0;
	private bool isDead;

	private void Awake()
	{
		rigidbody2d = GetComponent<Rigidbody2D>();
		gameEventHandler = FindObjectOfType<GameEventHandler>();
		mainCamera = Camera.main;
	}

	private void Start()
	{
		
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
			if (!isDead)
			{
				Dead();
			}
		}
		else if (collision.gameObject.CompareTag("Item"))
		{
			GetItem(collision.gameObject.transform.parent.gameObject);
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
				rigidbody2d.AddForce(new Vector2(0, -ySpeed / 2f));
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

		mainCamera.GetComponent<CameraShake>().Shake();

		EmitDeadEffect();
		StopPlayer();
		gameEventHandler.OnGameOver();
	}

	private void GetItem(GameObject item)
	{
		gameEventHandler.OnGetItem();

		Destroy(Instantiate(itemEffect, item.transform.position, Quaternion.identity), 0.5f);
		Destroy(item);
		gameEventHandler.AddScore(1);
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
