using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleParent : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
		StartCoroutine(CalculateDistanceToPlayer());
    }

    private IEnumerator CalculateDistanceToPlayer()
	{
		while (true)
		{
			if (player.transform.position.y - transform.position.y > 50)
			{
				Destroy(gameObject);
			}
            yield return new WaitForSeconds(1f);
		}
	}
}
