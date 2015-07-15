using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

//Generates a value between 0 and 1 for a Tony Hawk-style balancing mechanic
public class Balancer : MonoBehaviour {

	public float Gravity = 0.98f;
	public float MaxValue = 1.0f;

	private float angAcceleration = 0.0f;
	private float angVelocity = 0.0f;
	private float angle = 0.0f;
	private float value = 0.0f;

	void Start () {
		//Initializes the angle to a random non-zero value in a narrow range centered around 0
		while (angle == 0) {
			angle = (Random.value - 0.5f) * Mathf.PI / 16;
		}
	}
	
	void FixedUpdate () {
		//Uses a physics-based balancing mechanic, based on the idea of balancing a broom on end
		angAcceleration = (3 * Gravity * Mathf.Sin(angle)) / Mathf.Pow(MaxValue, 3);
		angVelocity += angAcceleration;
		angle += angVelocity;
		value = MaxValue * Mathf.Sin(angle);
	}
}
