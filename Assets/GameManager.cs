using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour {
	float countdownTime;
	int countDown = 3;

	public float joustSpeed;
	public CharacterController jouster1;
	public CharacterController jouster2;
	public Text countdownUI;

	// Use this for initialization
	void Start () {
		countdownTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (countDown != 0 && Time.time - countdownTime > 1) {
			countdownTime = Time.time;
			countDown--;
			countdownUI.text = "" + countDown;
		}
	}
}
