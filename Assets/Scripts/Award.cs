using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AwardType{
	AuardBullet,
	AuardBmob
}
// 奖励物品脚本
public class Award : MonoBehaviour {
	// 子弹奖励的时间
	public static float BULLET_TIME = 10f;
	
	// 奖励的烈性
	public AwardType type =AwardType.AuardBullet;
	// 下降的速度
	public float speed = 2f; 
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// 往下走
		transform.Translate(Vector3.down*speed*Time.deltaTime);
		// 如果超出,销毁
		if(transform.position.y<-4.9f){
			Destroy(this.gameObject);
		}
	}
}
