using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_WeaponRot : MonoBehaviour{
	//この回転機能を有効にするには、WeaponAimを無効化する事
	[Header("Shot Angle(WeaponAim be Disable!!)")]
	public float z;

	void Start(){
		this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, z);
	}
}
