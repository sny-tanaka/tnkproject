using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSet : MonoBehaviour {

	// 外部から設定する
	public bool ifPlayer;
	public int personalMonsterID;

	// 各種ステータス
	public string monsterName;
	public int type;
	public int lv;
	public int maxHp;
	public int[] atk = new int[4];
	public int gAtk;
	public int cAtk;
	public int pAtk;
	public int def;

	// 技の設定
	public string[] skillNames = new string[4];
	public int[] skillpows = new int[4];

	// 現在HP
	public int hp;

	void Start(){
		// CSVReader取得
		CSVReader csvReader = GameObject.Find("CSVReader").GetComponent<CSVReader>();

		// PlayerMonsterもしくはEnemyMonsterからplayerMonsterIDの行だけを配列として取得
		if (ifPlayer){
			string[] personalMonsterDatas = csvReader.CSVReadLine("PlayerMonster", parsonalMonsterID);
		} else {
			string[] personalMonsterDatas = csvReader.CSVReadLine("EnemyMonster", parsonalMonsterID);
		}

		// レベルを更新
		lv = int.Parse(personalMonsterDatas[2]);

		// MonsterからMonsterIDの行を配列として取得
		string[] monsterDatas = csvReader.CSVReadLine("Monster", int.Parse(personalMonsterDatas[1]));

		// monsterDatasとpersonalMonsterDatasからステータスを算出
		monsterName = monsterDatas[1];
		type = int.Parse(monsterDatas[2]);
		maxHp = int.Parse(monsterDatas[3]) + int.Parse(monsterDatas[3])*(lv-1)*2/5 + int.Parse(personalMonsterDatas[3]);
		gAtk = int.Parse(monsterDatas[4]) + int.Parse(monsterDatas[4])*(lv-1)*2/5 + int.Parse(personalMonsterDatas[4]);
		cAtk = int.Parse(monsterDatas[5]) + int.Parse(monsterDatas[5])*(lv-1)*2/5 + int.Parse(personalMonsterDatas[5]);
		pAtk = int.Parse(monsterDatas[6]) + int.Parse(monsterDatas[6])*(lv-1)*2/5 + int.Parse(personalMonsterDatas[6]);
		def = int.Parse(monsterDatas[7]) + int.Parse(monsterDatas[7])*(lv-1)*2/5 + int.Parse(personalMonsterDatas[7]);

		// Skillから技データを取得し格納
		for (int i=0; i<4; i++){
			string[] skillDatas = csvReader.CSVReadLine("Skill", int.Parse(personalMonsterDatas[i+8]));
			skillNames[i] = skillDatas[1];
			skillpows[i] = skillDatas[3];
		}

		// HPを最大値に設定
		hp = maxHp;

		// 画像をフォルダから探して設定

	}
}
