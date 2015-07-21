using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]
public class JousterBoost : MonoBehaviour {

	public float boostSpeed;
	public float boostFalloff;

	CharacterController jouster;

	// Use this for initialization
	void Start () {
		jouster = gameObject.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Boost")) {
			jouster.Move(Vector3.forward * Time.deltaTime);
		}
	}
}
