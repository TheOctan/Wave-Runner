using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
	public float duration = 0.15f;
	public float magnitude = 0.2f;

	public void Shake()
	{
		StartCoroutine(ShakeAnimation());
	}

	private IEnumerator ShakeAnimation()
	{
		Vector3 originalposition = transform.position;
		float elapsed = 0f;

		while (elapsed < duration)
		{
			float x = Random.Range(-1f, 1f) * magnitude;
			float y = Random.Range(-1f, 1f) * magnitude;

			transform.localPosition = new Vector3(originalposition.x + x, originalposition.y + y, originalposition.z);
			elapsed += Time.deltaTime;
			yield return null;
		}

		transform.localPosition = originalposition;
	}


}
