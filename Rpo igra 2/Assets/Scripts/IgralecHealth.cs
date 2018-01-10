using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IgralecHealth : MonoBehaviour {

	[SerializeField]
	private Text HealthText;
	private float Health = 100;

	public void TakeHealth(int value){
		Health -= value;
		if (Health <= 0) {
			GameObject.FindGameObjectWithTag ("LevelManager").GetComponent<LevelManager> ().PlayerKilled ();
			HealthText.text = string.Empty;
		} else {
			HealthText.text = Health.ToString ();
		}
	}



}
