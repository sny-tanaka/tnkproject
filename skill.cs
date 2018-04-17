using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill : MonoBehaviour {

	// タイプ管理, 外部から設定する
	public int typeID;

	// プレイヤーかエネミーか
	public bool ifPlayer;

	public void sendChoicedType(){
		// ButtleManagerに選択コマンドを送る
		if (ifPlayer){
			GameObject.Find("ButtleManager").GetComponent<ButtleManager>().playerChoicedType = typeID;
			GameObject.Find("Enemy").GetComponent<skill>().sendChoicedType();
		} else {
			int a = Random.Range(0, 4);
			typeID = a;
			GameObject.Find("ButtleManager").GetComponent<ButtleManager>().enemyChoicedType = typeID;
		}
	}
}
