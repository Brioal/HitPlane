using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	// 子弹移动的速度(每次时间间隔往上移动的位置)
	public float speed = 2;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.up*speed*Time.deltaTime); 
		if(transform.position.y>=4.05f){
			// 销毁
			Destroy(this.gameObject);
		}
	}

	// 子弹碰撞到其他物体的事件
	void OnTriggerEnter2D(Collider2D other){
		
		if(other.tag=="Enemy"){
			other.gameObject.SendMessage("BeHit");
			// 销毁子弹
			if(!other.GetComponent<Enemy>().isDeaded){
				Destroy(this.gameObject);
			}
			
		}
	}
}
