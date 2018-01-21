using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour {


	void OnCollisionEnter(Collision collision){ // ko zazna da trčita dva predmeta se avtomatsko kliče ta metoda
		Debug.Log("Trofo");
		if(collision.gameObject.CompareTag("Bot")){
			Debug.Log("TrofoBota");
			collision.gameObject.GetComponent<BotHealth> ().TakeHealth (10);
		}
		Destroy(gameObject); // uničimo kroglo
	}
		

}
