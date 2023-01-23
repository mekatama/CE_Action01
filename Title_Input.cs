using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.Tools;


public class Title_Input : MonoBehaviour{

	void Update(){
		if(Input.anyKey){
			//ロード画面呼び出してScene遷移
			MMSceneLoadingManager.LoadScene("Test01_Scene1");
		}
	}
}
