using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	// 各種ステータス
	public int maxhp = 200;
	public int atk = 100;
	public int defend = 120;
	public int matk = 100;
	public int mdefend = 100;
	public int speed = 100;
	public int[] type = new int[2];
	public int roll = 1;
	public int identity = 1;

	public int hp;

	// HPバー
	Slider enemyhpslider;
	
	void Start(){
		hp = maxhp;
		enemyhpslider = GameObject.Find("EnemyHpSlider").GetComponent<Slider>();
		enemyhpslider.maxValue = maxhp;
	}

	void Update(){
		// HPバーの値を現在HPに変更し、割合に応じて緑から赤へ徐々に変化させる
		enemyhpslider.value = hp;
		enemyhpslider.fillRect.GetComponent<Image>().color = Color.Lerp(Color.red, Color.green, (float)hp/maxhp);
	}
}
