using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour {

	[SerializeField]
	private GameObject Efekt; // efekt ki ga spawnamo ob zadetku in izstrelitvi krogle

	void OnEnable(){ // takoj ko se spawna krogla
		GameObject Effect = Instantiate (Efekt, gameObject.transform.position, gameObject.transform.rotation); // naredimo vizualni efekt (eksplozija)
		Destroy (Effect, 0.5f); // in uničimo efekt čez 0.5 sekunde
	}

	void OnCollisionEnter(Collision collision){ // ko zazna da trčita dva predmeta se avtomatsko kliče ta metoda
		if(collision.gameObject.CompareTag("Bot")){ // če je krogla zadela bota ...
			Destroy (collision.gameObject); // ... uničimo bota
		}
		GameObject Effect = Instantiate (Efekt, gameObject.transform.position, gameObject.transform.rotation); // spawnamo vizualni efekt ko krogla zadene nekaj
		Destroy (Effect, 0.5f);
		Destroy(gameObject); // uničimo kroglo
	}

	/*
	 * OPOMBA:
	 * Efekt deluje ampak je malo zamaknjen, bom do naslednjič pogledal kaj je težava
	 * Komentarje lahko daš ven iz te kode pa jih prepišeš v poročilo če hočeš 
	 * 
	 */

}
