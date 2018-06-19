using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Running,
    Pause
}
public class GameManager : MonoBehaviour
{

    public static GameManager _instance;
    // 当前的分数
    public int score = 0;
    // 游戏状态
    public GameState gameState = GameState.Running;

    // 音频播放器
    private AudioSource audioSource;

    void Awake()
    {
        _instance = this;
    }

    // 暂停游戏
    public void pauseGame()
    {
       
		 Time.timeScale =0;
		gameState = GameState.Pause;
    }

    // 继续游戏
    public void continueGame()
    {
        Time.timeScale = 1;
		gameState = GameState.Running;
    }

    public void transformGameState()
    {
        if (gameState == GameState.Running)
        {
            pauseGame();
            // 暂停播放
            audioSource.Pause();
        }
        else
        {
            continueGame();
            // 继续播放
            audioSource.Play();
        }
    }


    void Start()
    {   
        // 赋值
        audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
