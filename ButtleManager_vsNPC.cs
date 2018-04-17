using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtleManager_vsNPC : MonoBehaviour {

	// 外部から設定される
	public int[] playerChoicedHand = new int[3];
    public int enemyChoicedHand;

    // 勝ち負け
    int[] WoL = new int[3];

    GameObject[] playerHand = new GameObject[3];
    GameObject enemyHand;

    void Start(){
        // 両ハンドのオブジェクトを取得
        for (int i=0; i<3; i++){
            playerHand[i] = GameObject.Find("player"+ (i+1).ToString() +"Hand");
        }
        enemyHand = GameObject.Find("enemyHand");
    }

    // スタートの掛け声
    void priming(){
        // 画面中央に"じゃんけん"と表示
        
    }

    // NPCの出手を決める
    void enemyRandomHand(){
        // enemyの手をランダムで決める
        int h = Random.Range(1, 4);
        enemyChoicedHand = h;
    }

    // 全員の手を画面上に表示する
    void displayHands(){

    }

    // 手の勝ち負けを判定する
    void WoLJudge(){

    }

    // ダメージ計算
    void damageCulc(){
        float originalDmg;
        int dmg;
        for (int i=0; i<3; i++){
            if (WoL[i] == 0){
                break;
            }
            // 攻撃側と防御側のコンポーネント取得
            CharaSet atkSide;
            CharaSet defSide;
            int handType;
            if (WoL[i] == 1){
                atkSide = GameObject.Find("Player"+ (i+1).ToString()).GetComponent<CharaSet>();
                defSide = GameObject.Find("Enemy").GetComponent<CharaSet>();
                handType = playerChoicedHand[i];
            } else {
                atkSide = GameObject.Find("Enemy").GetComponent<CharaSet>();
                defSide = GameObject.Find("Player"+ (i+1).ToString()).GetComponent<CharaSet>();
                handType = enemyChoicedHand;
            }

            // 必要数値の設定
            int atkType = atkSide.type;
            int defType = defSide.type;
            int atk = atkSide.status[handType];
            int pow = atkSide.skillpows[handType];
            int rand = Random.Range(85, 101);
            int def = defSide.status[handType];

            // 基本ダメージ
            originalDmg = atk**2 * pow * rand / (atk+def) / 10000.0f;

            // タイプ一致ボーナス
            if (atkType == handType){
                originalDmg *= 1.2f;
            }

            // 弱点・耐性ボーナス
            int chemi = judgingDeadlock(atkType, defType);
            if (chemi == 1){
                originalDmg *= 1.5f;
            } else if (chemi == 2){
                originalDmg *= 0.8f;
            }

            // 小数点以下切り捨て
            dmg = (int)originalDmg;
        }
    }

    // 3すくみのa目線の勝ち負け判定(勝ち=1,負け=2,あいこ=0)
    int judgingDeadlock(int a, int b){
        if (a == b){
            return 0;
        } else if (a==1 && b==3){
            // aがグー、bがパー
            return 2;
        } else if (a==3 && b==1){
            // aがパー、bがグー
            return 1;
        } else if (a < b){
            return 1;
        } else {
            return 2;
        }
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
