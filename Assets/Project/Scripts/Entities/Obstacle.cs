using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int rotationSpeed;

    private void Update()
    {
		if (rotationSpeed != 0)
		{
			Rotate();
		}
    }

    private void Rotate()
	{
		transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
	}
}
