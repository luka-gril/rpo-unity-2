using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotPremikanje : MonoBehaviour {

	private NavMeshAgent NavMeshAgentKomponenta;
	private Transform mPlayerTransform;

	void Start () {
		NavMeshAgentKomponenta = GetComponent<NavMeshAgent> ();
		mPlayerTransform = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
	}

	void Update () {
		Vector3 playerPosition = mPlayerTransform.position;
		NavMeshAgentKomponenta.SetDestination (playerPosition);
	}


}
