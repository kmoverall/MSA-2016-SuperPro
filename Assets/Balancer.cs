using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

//Generates a value between 0 and 1 for a Tony Hawk-style balancing mechanic
public class Balancer : MonoBehaviour {

	public float MaxValue = 110f;
	public float MarginOfError = 5f;
	public float InitialGravity = 0.001f;
	public float GravityIncreaseRate = 0.0005f;
	public float AxisSensitivity = 0.0005f;
	public float AxisDeadZone = 0.1f;

	private float axisAcceleration = 0.0f;
	private float gravity;
	private float angAcceleration = 0.0f;
	private float angVelocity = 0.0f;
	private float angle = 0.0f;
	protected float balanceValue = 0.0f;

	protected void Start () {
		gravity = InitialGravity;
		//Initializes the angle to a random non-zero value in a narrow range centered around 0
		while (angle == 0) {
			angle = (Random.value - 0.5f) * Mathf.PI / 16;
		}
	}
	
	protected void FixedUpdate () {

		gravity += GravityIncreaseRate * Time.fixedDeltaTime;

		//Uses a physics-based balancing mechanic, based on the idea of balancing a broom on end
		angAcceleration = (3 * gravity * Mathf.Sin(angle)) / MaxValue + axisAcceleration;

		//Prevents roll over
		if (!(balanceValue > MaxValue - MarginOfError && angAcceleration > 0) && !(balanceValue < -1 * MaxValue + MarginOfError && angAcceleration < 0)) {
			angVelocity += angAcceleration;
			if (!(balanceValue > MaxValue - MarginOfError && angVelocity > 0) && !(balanceValue < -1 * MaxValue + MarginOfError && angVelocity < 0)) {
				angle += angVelocity;
				balanceValue = MaxValue * Mathf.Sin(angle);
			}
		}
	}

	protected void ApplyTorque(float axisValue) {
		if (Mathf.Abs(axisValue) > AxisDeadZone) {
			Debug.Log(axisValue);
			axisAcceleration = axisValue * AxisSensitivity;
		}
	}
}
