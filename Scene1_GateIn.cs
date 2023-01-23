using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.Tools;

public class Scene1_GateIn : MonoBehaviour{
	//Gateに接触したらScene移動
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player"){
			//ロード画面呼び出してScene遷移
			MMSceneLoadingManager.LoadScene("Test01_Title");
		}
	}
}
