﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmo : MonoBehaviour
{
	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(transform.position, 0.5f);
	}
}
