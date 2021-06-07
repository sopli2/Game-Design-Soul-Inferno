﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{

	private bool hasEntered;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == ("Death") && !hasEntered)
		{
			hasEntered = true;
			Destroy(gameObject);
			LevelManager.instance.Respawn();
		}
	}
}