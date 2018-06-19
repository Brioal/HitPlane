using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgTranstorm : MonoBehaviour {

    public float moveSpeed = 2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // 每次刷新向下移动
        this.transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        Vector3 position = this.transform.position;
        // 如果顶部已经大于高度
        if (position.y < -8.52f)
        {
            // 移动到顶部
            this.transform.position = new Vector3(position.x,position.y+8.52f*2,position.z);
        }
	}
}
