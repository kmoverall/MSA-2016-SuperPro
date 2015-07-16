using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

//Generates a value between 0 and 1 for a Tony Hawk-style balancing mechanic
public class Balancer : MonoBehaviour {

	public float Gravity = -0.98f;
	public float MaxValue = 1.0f;

	private float angAcceleration = 0.0f;
	private float angVelocity = 0.0f;
	private float angle = 0.0f;
	protected float balanceValue = 0.0f;

	protected void Start () {
		//Initializes the angle to a random non-zero value in a narrow range centered around 0
		/*while (angle == 0) {
			angle = (Random.value - 0.5f) * Mathf.PI / 16;
		}*/
		angle = Mathf.PI / 4;
	}
	
	protected void FixedUpdate () {
		if (balanceValue < MaxValue && balanceValue > -1 * MaxValue) {
			Debug.Log("Update");
			//Uses a physics-based balancing mechanic, based on the idea of balancing a broom on end
			angAcceleration = (3 * Gravity * Mathf.Sin(angle)) / Mathf.Pow(MaxValue, 2); //angle is being used incorrectly here
			angVelocity += angAcceleration;
			angle += angVelocity; //which angle is this referring to? Fix
			balanceValue = MaxValue * Mathf.Sin(angle);
		}
	}
}
