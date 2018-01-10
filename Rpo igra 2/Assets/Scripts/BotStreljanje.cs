using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotStreljanje : MonoBehaviour {

	[SerializeField]
	private GameObject Bullet;
	private float ShootingTime = 1.5f;
	private float Timer = 0f;

	void Update () {
		Timer += Time.deltaTime;
		if (Timer >= ShootingTime) {
			Shoot ();
			Timer = 0f;
		}
	}

	private void Shoot(){
		GameObject igralec = GameObject.FindGameObjectWithTag ("Igralec");
		GameObject bullet = (GameObject) Instantiate (Bullet, gameObject.transform.position, gameObject.transform.rotation);
		Vector3 direction = (igralec.transform.position - gameObject.transform.position).normalized;
		direction.y = 0f;
		bullet.GetComponent<Rigidbody> ().AddForce (direction * 400f);
		gameObject.GetComponent<AudioSource> ().Play ();
	}

}
