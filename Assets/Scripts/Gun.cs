using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{


    // 隔多久一发子弹
    private float rate = 0.3f;
    // 子弹的类型
    public GameObject buulet;


    // 创建子弹
    public void fire()
    {
        if(!this.gameObject.active){
            return;
        }
        GameObject.Instantiate(buulet, transform.position, Quaternion.identity);
        // 播放音效
        this.GetComponent<AudioSource>().Play();
    }

	// 开火
	public void openFire(){
		InvokeRepeating("fire",0.011f,rate);
	}

    void Start()
    {
		// 开火
		openFire();
    }


    void Update()
    {
        
    }
}
