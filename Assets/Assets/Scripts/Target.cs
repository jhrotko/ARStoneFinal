using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
	public float timeAfterHit = .5f;

	public void Hit()
	{
		Destroy(gameObject, timeAfterHit);
	}
}
