using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// 各種ステータス
	public int maxhp = 200;
	public int atk = 100;
	public int defend = 100;
	public int matk = 100;
	public int mdefend = 100;
	public int speed = 100;
	public int[] type = new int[2];
	public int roll = 1;
	public int identity = 1;

	// 技の設定
	public string[] skills = new string[4];

	// 場に出ているかどうか
	public bool activeFlag;

	void Start(){
		int hp = maxhp;
	}
}
