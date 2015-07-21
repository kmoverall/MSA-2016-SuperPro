using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

//Generates a value between 0 and 1 for a Tony Hawk-style balancing mechanic
[System.Serializable]
public class Balancer {

	public float MaxValue = 110f;
	[SerializeField] 
	private float MarginOfError = 5f;
	[SerializeField]
	private float InitialGravity = 0.001f;
	[SerializeField]
	private float GravityIncreaseRate = 0.0005f;
	[SerializeField]
	private float AxisSensitivity = 0.0005f;
	[SerializeField]
	private float AxisDeadZone = 0.1f;

	private float axisAcceleration = 0.0f;
	private float gravity;
	private float angAcceleration = 0.0f;
	private float angVelocity = 0.0f;
	private float angle = 0.0f;

	public float balanceValue = 0.0f;

	public void Initialize() {
		gravity = InitialGravity;
		//Initializes the angle to a random non-zero value in a narrow range centered around 0
		while (angle == 0) {
			angle = (Random.value - 0.5f) * Mathf.PI / 16;
		}
	}
	
	public void UpdateBalance () {

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

	public void ApplyTorque(float axisValue) {
		if (Mathf.Abs(axisValue) > AxisDeadZone) {
			axisAcceleration = axisValue * AxisSensitivity;
		}
	}
}
