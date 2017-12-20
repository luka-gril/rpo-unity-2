using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotPremikanje : MonoBehaviour {

	private NavMeshAgent NavMeshAgentKomponenta;
	private Transform mPlayerTransform;
	private Animator mBotAnimator; // komponenta za animacije

	void Start () {
		NavMeshAgentKomponenta = GetComponent<NavMeshAgent> (); 
		mPlayerTransform = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Transform> ();
		mBotAnimator = GetComponent<Animator> ();
	}

	void Update () {
		Vector3 playerPosition = mPlayerTransform.position;
		NavMeshAgentKomponenta.SetDestination (playerPosition);

		if (NavMeshAgentKomponenta.velocity == Vector3.zero) { // če bot stoji na mestu
			mBotAnimator.SetBool ("Running", false); // nastavimo running spremenljivko na 0, kar menja animacijo na mirovanje
		} else {
			mBotAnimator.SetBool ("Running", true); // drugače nastavimo running na true kar menja animacijo na tekanje
		}

	}


}
