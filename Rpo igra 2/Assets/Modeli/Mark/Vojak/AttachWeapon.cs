using UnityEngine;
using System.Collections;

public class AttachWeapon : MonoBehaviour {
	
	public Transform attachPoint;
	public Transform Weapon;

	void Start () {
		Weapon.parent = attachPoint;
		Weapon.position = attachPoint.position;
		Weapon.rotation = attachPoint.rotation;
	}

}
