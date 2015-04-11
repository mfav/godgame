﻿using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {

	private Vector3 _startPos;

	// Use this for initialization
	void Start () {
		_startPos = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LookingAt(GameObject looker) {
		var dest = Vector3.Lerp(_startPos, looker.transform.position, 0.33f);
		iTween.MoveTo(gameObject, dest, 0.5f);
	}

	void StopLookingAt() {
		iTween.MoveTo(gameObject, _startPos, 0.5f);
	}
}
