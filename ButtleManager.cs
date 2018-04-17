using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtleManager : MonoBehaviour {

	// 外部から設定される
	public int playerChoicedType;
    public int enemyChoicedType;

    GameObject playerHand;
    GameObject enemyHand;

    void Start(){
        // 両ハンドのオブジェクトを取得
        playerHand = GameObject.Find("playerHand");
        enemyHand = GameObject.Find("enemyHand");
    }

	public void judgement(){

		// 頭上にタイプ画像を表示する
        //playerHand.GetComponent<Image>().sprite;
        //enemyHand.GetComponent<Image>().sprite;

        // 1秒待機
        StartCoroutine ("waitSeconds", 1);

        // 中央に向かって移動スタート
        StartCoroutine ("movingHand");

    }

    IEnumerator movingHand(){
        // 両ハンドを中央に向かって動かす
        Vector2 pos;
        for (int i=0; i<80; i++){
            pos = playerHand.transform.position;
            pos.x += 1;
            playerHand.transform.position = pos;
            pos = enemyHand.transform.position;
            pos.x -= 1;
            enemyHand.transform.position = pos;
            yield return 0;
        }

        // 勝負の判定
        int judge;
        if (playerChoicedType == enemyChoicedType){
            // あいこ
            judge = 0;
        } else if (playerChoicedType == 1 && enemyChoicedType == 3){
            // プレイヤーがグー、エネミーがパー
            judge = 2;
        } else if (playerChoicedType == 3 && enemyChoicedType == 1){
            // プレイヤーがパー、エネミーがグー
            judge = 1;
        } else if (playerChoicedType < enemyChoicedType){
            // プレイヤーの勝ち
            judge = 1;
        } else {
            // プレイヤーの負け
            judge = 2;
        }

        // 勝ち負けによる処理
        switch (judge)
        {
            case 1: // 勝ち
                // enemyHandを爆発させる
                enemyHand.GetComponent<Image>().sprite = GameObject.Find("bomb").GetComponent<SpriteRenderer>().sprite;
                for (int i=0; i<20; i++){
                    // playerHandをさらに動かす
                    pos = playerHand.transform.position;
                    pos.x += 1;
                    playerHand.transform.position = pos;
                    yield return 0;
                }
                // enemyHandのイメージを消す
                enemyHand.GetComponent<Image>().sprite = null;
                break;

            case 2: // 負け
                // playerHandを爆発させる
                playerHand.GetComponent<Image>().sprite = GameObject.Find("bomb").GetComponent<SpriteRenderer>().sprite;
                for (int i=0; i<20; i++){
                    // enemyHandをさらに動かす
                    pos = enemyHand.transform.position;
                    pos.x -= 1;
                    enemyHand.transform.position = pos;
                    yield return 0;
                }
                // playerHandのイメージを消す
                playerHand.GetComponent<Image>().sprite = null;
                break;

            case 0: // あいこ
                
                break;
        }
	}

    IEnumerator waitSeconds(float s){
        yield return new WaitForSeconds (s);
    }
}
