using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	[SerializeField]
	private GameObject Metek;
	[SerializeField]
	private GameObject OstanekMetka;
	private float casStreljanja = 0.1f;
	private float mTimer = 0f;

	void Update(){
		mTimer += Time.deltaTime;
		if (Input.GetMouseButton (0) && mTimer > casStreljanja) {
			ShootBullet ();
			mTimer = 0f;
		}
	}
		
	private void ShootBullet(){
		GameObject metek = Instantiate (Metek, gameObject.transform.position, gameObject.transform.rotation);
		GameObject ostanekMetka = Instantiate (OstanekMetka, gameObject.transform.position, Quaternion.identity);
		ostanekMetka.GetComponent<Rigidbody> ().AddTorque (new Vector3 (1, 1, 1) * Random.Range (-20, 20)); // doda ostanku metka neko random rotacijo da se malo vrtijo v zraku
		Destroy (ostanekMetka, 3f); // uniči ostanek metka čez 3 sekunde
		metek.GetComponent<Rigidbody> ().AddForce (metek.transform.forward * 500f);
	}


}
