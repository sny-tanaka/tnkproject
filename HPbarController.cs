using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbarController : MonoBehaviour {

	// メインゲージのSliderオブジェクトの設定
	public GameObject mainBar;
	Slider mainSlider;

	// ダメージ量表示用のSliderオブジェクトの設定
	public GameObject subBar;
	Slider subSlider;

	// 設定数値
	public int maxHp;
	public int hp;

	void Start () {
		// Sliderコンポーネントの取得
		mainSlider = mainBar.GetComponent<Slider>();
		subSlider = subBar.GetComponent<Slider>();

		// 最大値の設定
		mainSlider.maxValue = maxHp;
		subSlider.maxValue = maxHp;

		// 現在値を最大HPに設定
		hp = maxHp;
		mainSlider.value = hp;
		subSlider.value = hp;
	}
	
	public void barDecrease(){
		// メインゲージを即現在HPに変更する
		mainSlider.value = hp;

		// サブゲージを減らすコルーチンを呼びだす
		StartCoroutine ("subBarDecrease");
	}

	IEnumerator subBarDecrease(){
		// 現在HPの値になるまで徐々に減らす
		float f = subSlider.value;
		while (f != hp){
			f -= 1;
			subSlider.value = f;
			yield return 0;
		}
	}
}
