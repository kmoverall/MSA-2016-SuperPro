using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent (typeof(Image))]
public class BalanceField : MonoBehaviour {

	public Image marker;
	Image panel;

	public Balancer xBalancer;
	public Balancer yBalancer;

	// Use this for initialization
	void Start () {
		xBalancer.Initialize();
		yBalancer.Initialize();
		panel = gameObject.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		xBalancer.ApplyTorque(Input.GetAxis("Horizontal"));
		yBalancer.ApplyTorque(Input.GetAxis("Vertical") * -1);

		xBalancer.UpdateBalance();
		yBalancer.UpdateBalance();

		Vector2 newPosition;

		newPosition.x = xBalancer.balanceValue / xBalancer.MaxValue * panel.rectTransform.sizeDelta.x / 2;
		newPosition.y = yBalancer.balanceValue / xBalancer.MaxValue * panel.rectTransform.sizeDelta.y / 2;
		marker.rectTransform.anchoredPosition = newPosition;
	}
}
