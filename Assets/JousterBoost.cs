using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]
public class JousterBoost : MonoBehaviour {

	public float boostSpeed;
	public float boostFalloff;
	public float maxSpeed;

	float jousterVelocity;

	CharacterController jouster;

	// Use this for initialization
	void Start () {
		jouster = gameObject.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Boost")) {
			jousterVelocity += boostSpeed;
			jousterVelocity = Mathf.Min(maxSpeed, jousterVelocity);
		}
		jouster.Move(Vector3.forward * Time.deltaTime * jousterVelocity);
		jousterVelocity -= boostSpeed * Time.deltaTime;
		jousterVelocity = Mathf.Max(0, jousterVelocity);
	}

	void OnControllerColliderHit() {
		Application.LoadLevel(0);
	}
}
