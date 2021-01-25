using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
	public GameObject player;
	public GameObject[] obstacles;

	int obstacleCount;

	int playerDistanceIndex = -1;
	int obstacleIndex = 0;
	int distanceToNext = 50;

	private void Start()
	{
		obstacleCount = obstacles.Length;
		InstatiateObstacle();
	}

	private void Update()
	{
		int playerDistance = (int)(player.transform.position.y / distanceToNext);

		if (playerDistanceIndex != playerDistance)
		{
			InstatiateObstacle();
			playerDistanceIndex = playerDistance;
		}
	}

	public void InstatiateObstacle()
	{
		int randomIndex = Random.Range(0, obstacleCount);
		var newPosition = Vector3.up * obstacleIndex * distanceToNext;
		Instantiate(obstacles[randomIndex], newPosition, Quaternion.identity, transform);
		obstacleIndex++;
	}
}
