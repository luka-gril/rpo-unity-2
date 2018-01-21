using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHitEnemy : MonoBehaviour {

	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.CompareTag("Igralec")){
			collision.gameObject.GetComponent<IgralecHealth> ().TakeHealth (25);
		}
		Destroy(gameObject); 
	}

}
