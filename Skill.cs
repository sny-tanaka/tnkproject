using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill : MonoBehaviour {

	public int pow = 40;
	public int skillType = 1;

	// Enemyコンポーネント
	Enemy enemy;

	// Playerコンポーネント
	Player player;

	void Start(){
		enemy = GameObject.Find("Enemy").GetComponent<Enemy>();
		player = GameObject.Find("Player").GetComponent<Player>();
	}

	public void damageCulc(){
		// ダメージ計算
		float damage = 22 * player.atk * pow / enemy.defend / 50 + 2;
		damage = damage * Random.Range(85, 101) / 100;
		int dam = (int)damage;
		enemy.hp = enemy.hp - dam;
	}
}
