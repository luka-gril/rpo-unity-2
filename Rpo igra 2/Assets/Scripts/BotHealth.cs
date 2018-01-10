using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotHealth : MonoBehaviour {

	private float Health = 100;

	public void TakeHealth(int value){
		Health -= value;
		if (Health <= 0) {
			Destroy (gameObject);
		} 
	}

}
