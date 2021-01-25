using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoCircleMarker: MonoBehaviour
{
	[ColorUsage(false)]
	public Color color = Color.white;
	public float radius = 0.5f;

	private void OnDrawGizmos()
	{
		Gizmos.color = color;
		Gizmos.DrawWireSphere(transform.position, radius);
	}
}
