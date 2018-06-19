using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour {

	// Use this for initialization
	// 暂停的资源
	public Sprite pauseSprite;
	// 开始的资源
	public Sprite startSprite;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseUpAsButton(){
		GameManager._instance.transformGameState();
		if(GameManager._instance.gameState==GameState.Running){
			this.GetComponent<SpriteRenderer>().sprite = pauseSprite;
		}else{
			this.GetComponent<SpriteRenderer>().sprite = startSprite;
		}
		// 播放点击声音
		this.GetComponent<AudioSource>().Play();
	}
}
