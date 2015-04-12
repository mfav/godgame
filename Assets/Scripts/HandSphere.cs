﻿using UnityEngine;
using System.Collections;

public class HandSphere : MonoBehaviour {

	// Set these
	public GameObject GroundIndicator;
	public LineRenderer Line;

	// Use this for initialization
	void Start () {
	
	}

	bool hitGround = false;
	
	// Update is called once per frame
	void Update () {
		var player = KinectStream.Instance.getPlayer();

		if (player != null)
			this.transform.localPosition = player.getJoint(11);

		var hit = new RaycastHit();

		if (Physics.Raycast(transform.position, transform.up * -1, out hit, 10f) && hit.collider.gameObject.CompareTag("Board")) {
			GroundIndicator.SetActive(true);
			GroundIndicator.transform.position = hit.point;
			if (!hitGround) {
				GroundIndicator.transform.localScale = new Vector3(0.1f, 0.005f, 0.1f);
				iTween.ScaleTo(GroundIndicator, iTween.Hash("scale", new Vector3(1, 0.005f, 1), "time", 1f));
				hitGround = true;
			}
			Line.SetPosition(0, this.transform.position);
			Line.SetPosition(1, GroundIndicator.transform.position);
		}
		else {
			GroundIndicator.SetActive(false);
			hitGround = false;
		}
	}

	void HitGround() {

	}

	void OnEnable() {

	}

	void OnDisable() {

	}
}