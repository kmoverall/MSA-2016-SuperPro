using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Slider))]
public class TriggerBalancer : MonoBehaviour {

	Slider slider;
	public Balancer balancer;

	// Use this for initialization
	void Start () {
		balancer.Initialize();
		slider = gameObject.GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
		balancer.ApplyTorque(Input.GetAxis("Triggers"));
		balancer.UpdateBalance();

		//A nasty way to transform the range -MaxValue .. MaxValue into slider.minValue .. slider.maxValue
		slider.value = (balancer.balanceValue / balancer.MaxValue + 1) * ((slider.maxValue - slider.minValue) / 2) + slider.minValue;
	}
}
