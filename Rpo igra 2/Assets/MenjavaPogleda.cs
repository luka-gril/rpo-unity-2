using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenjavaPogleda : MonoBehaviour {

	private int nastavljenPogled = 1; // belezimo trenutni pogled

	private Vector3 pogled1 = new Vector3 (0f, 3f, -4.15f); 
	private Vector3 rotacija1 = new Vector3 (19.38f, 0f, 0f);

	private Vector3 pogled2 = new Vector3 (0f, 2.1f, -2.2f);
	private Vector3 rotacija2 = new Vector3 (19f, 0f, 0.16f);

	private Transform KameraTransformKomponenta;

	void Start(){
		KameraTransformKomponenta = GetComponent<Transform> ();
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.C)) {
			MenjajPogled ();
		}
	}

	void MenjajPogled () {
		if (nastavljenPogled == 1) {
			KameraTransformKomponenta.localPosition = pogled2; 
			Quaternion rot = transform.localRotation; 
			rot.eulerAngles = rotacija2;
			KameraTransformKomponenta.localRotation = rot;
			nastavljenPogled = 2;
		} else {
			KameraTransformKomponenta.localPosition = pogled1;
			Quaternion rot = transform.localRotation;
			rot.eulerAngles = rotacija1;
			KameraTransformKomponenta.localRotation = rot;
			nastavljenPogled = 1;
		}
	}







}
