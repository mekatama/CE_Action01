using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.Tools;

public class Scene1_GateIn : MonoBehaviour{
	private float step_time;	//経過時間カウント用
	private bool isLoadScene;	//

	void Start(){
		step_time = 0.0f;		//経過時間初期化
		isLoadScene = false;
	}

	void Update(){
		if(isLoadScene == true){
			step_time += Time.deltaTime;	//経過時間をカウント
			if(step_time >= 1.0f){
				//ロード画面呼び出してScene遷移
				MMSceneLoadingManager.LoadScene("Test01_Title");
			}
		}

	}

	//Gateに接触したらScene移動
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player"){
			isLoadScene = true;
//			//ロード画面呼び出してScene遷移
//			MMSceneLoadingManager.LoadScene("Test01_Title");
		}
	}
}
