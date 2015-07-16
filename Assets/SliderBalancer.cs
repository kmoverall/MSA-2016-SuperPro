using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

[RequireComponent (typeof(Slider))]
public class SliderBalancer : Balancer {

	Slider slider;

	// Use this for initialization
	void Start () {
		base.Start();
		slider = gameObject.GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		base.FixedUpdate();
		slider.value = (balanceValue + MaxValue) * ((slider.maxValue - slider.minValue) / 2) + slider.minValue;
	}
}
