using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenjavaAnimacije : MonoBehaviour {

	private Animator AnimatorKomponenta;

	void Start () {
		AnimatorKomponenta = GetComponent<Animator> ();
		int tekanje = Animator.StringToHash("Tekanje");
		int mirovanje = Animator.StringToHash("Mirovanje");
		int streljanje = Animator.StringToHash("Streljanje");
		Debug.Log (tekanje.ToString ());
		Debug.Log (mirovanje.ToString ());
		Debug.Log (streljanje.ToString ());
		AnimatorKomponenta.SetTrigger (mirovanje);
	}

	void Update () {
		
	}
}
