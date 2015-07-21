using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

[RequireComponent (typeof(Slider))]
public class SliderBalancer : Balancer {

	/*Slider slider;
	string axis = "Horizontal";

	// Use this for initialization
	void Start () {
		base.Start();
		slider = gameObject.GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		base.FixedUpdate();

		ApplyTorque(Input.GetAxis(axis));
		//A nasty way to transform the range -MaxValue .. MaxValue into slider.minValue .. slider.maxValue
		slider.value = (balanceValue / MaxValue + 1) * ((slider.maxValue - slider.minValue) / 2) + slider.minValue;
		
	}*/
}
