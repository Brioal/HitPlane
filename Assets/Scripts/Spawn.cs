using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 生产敌机和物品的工厂
public class Spawn : MonoBehaviour {

	// 敌机一
	public GameObject enemy0Prehab;
	// 敌机二
	public GameObject enemy1Prehab;
	// 敌机三
	public GameObject enemy2Prehab;

	// 奖励一
	public GameObject award1Prehab;

	// 奖励二
	public GameObject award2Prehab;


	// 创建敌机一的速度
	public float enemy0Rate = 0.2f;
	// 创建敌机二的速度
	public float enemy1Rate = 2f;
	// 创建敌机三的速度
	public float enemy2Rate = 8f;

	// 创建奖励一的速度
	public float award1Rate = 5f;

	// 创建奖励二的速度
	public float award2Rate = 10f;

	// 创建奖励的音频
	public AudioSource awardSource;
	// 创建敌机三的生意
	public AudioSource enemy2Source;

	void Start () {
		InvokeRepeating("createEnemy0",1,enemy0Rate);
		InvokeRepeating("createEnemy1",5,enemy1Rate);
		InvokeRepeating("createEnemy2",14,enemy2Rate);

		InvokeRepeating("createAward1",5,award1Rate);
		InvokeRepeating("createAward2",8,award2Rate);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// 创建敌机一
	public void createEnemy0(){
		// 获取随机的X -2.1~4.5
		float x = Random.Range(-2.11f,2.06f);
		GameObject.Instantiate(enemy0Prehab,new Vector3(x,transform.position.y,1f),Quaternion.identity);
	}

	// 创建敌机二
	public void createEnemy1(){
		// 获取随机的X -2.1~4.5
		float x = Random.Range(-1.94f,1.88f);
		GameObject.Instantiate(enemy1Prehab,new Vector3(x,transform.position.y),Quaternion.identity);
	}

	// 创建敌机三
	public void createEnemy2(){
		// 获取随机的X -2.1~4.5
		float x = Random.Range(-1.4f,1.42f);
		GameObject.Instantiate(enemy2Prehab,new Vector3(x,transform.position.y),Quaternion.identity);
		// 播放声音
		enemy2Source.Play();
	}

	// 创建奖励一
	public void createAward1(){
		// 获取随机的X -2.1~4.5
		float x = Random.Range(-1.9f,1.97f);
		GameObject.Instantiate(award1Prehab,new Vector3(x,transform.position.y),Quaternion.identity);
		// 播放声音
		awardSource.Play();
	}

	// 创建奖励二
	public void createAward2(){
		// 获取随机的X -2.1~4.5
		float x = Random.Range(-1.9f,1.97f);
		GameObject.Instantiate(award2Prehab,new Vector3(x,transform.position.y),Quaternion.identity);
		// 播放声音
		awardSource.Play();
	}
}
