﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemIntensity : MonoBehaviour {

	public float timer = 0.1f;
	public float intensity_value = 0.5f;
	Light item_light;
	// TODO: Use things like Mathf.lerp to ACTUALLY do proper transitioning of light intensity values
	private bool light_flip = true;
	// Use this for initialization
	void Start () {
		item_light = GetComponent<Light>();
		// Debug.Log(item_light.intensity);
	}
	
	// Update is called once per frame
	void Update () {
		if (light_flip) {
			item_light.intensity += timer * Time.deltaTime;
		} else {
			item_light.intensity -= timer * Time.deltaTime;
		}

		if (item_light.intensity >= intensity_value || item_light.intensity <= 0) {
			light_flip = !(light_flip);
		}
	}
}
