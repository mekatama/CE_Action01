using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountTimer : MonoBehaviour{
	public float CountDownTime;	//カウントスタート値

	void Start(){
		CountDownTime = 60.0f;	//スタート値設定
	}

	void Update(){
		CountDownTime -= Time.deltaTime;	//カウントダウン
//		Debug.Log("counttime : " + CountDownTime);
	}
}
