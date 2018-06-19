using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemType
{
    EnemySmall,
    EnemyMiddle,
    EnemyLarge
}
// 敌人
public class Enemy : MonoBehaviour
{

    // 血量
    public int hp = 1;
    // 速度
    public float speed = 2;
    // 分数
    public int score = 100;
    // 飞机的类型
    public EnemType type = EnemType.EnemySmall;
    // 是否已经死亡
    public bool isDeaded = false;
    // 敌机的死亡动画
    public Sprite[] explosionSprites;
    // 计时器
    private float timer = 0;
    // 死亡动画播放帧数
    public int frameCount = 30;
    // 击中动画的帧数
    public int frameCountHit = 10;
    // 击中动画的计时器
    private float timerHit = 0;
    // 击中的画面
    public Sprite[] hitSprites;
    // 是否打中了
    private bool isHited = false;

	// 游戏管理器
	private GameManager gameManager;
    // 敌机爆炸声音
    public AudioSource  explosionAudio;

    void Start()
    {
		// 赋值
		gameManager = GameManager._instance;
    }

    // Update is called once per frame
    void Update()
    {
        // 向下运动
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        // 看不到的时候销毁
        if (transform.position.y <= -5.6f)
        {
            Destroy(this.gameObject);
        }
        // 处理死亡的动画
        action_dead();
        // 处理打中的动画
        action_hit();
    }

    // 处理打中的动画
    private void action_hit()
    {
        if (!isHited)
        {
            return;
        }
        if (hitSprites != null && hitSprites.Length > 0)
        {
            // 显示击中动画
            timerHit += Time.deltaTime;
            if (timerHit >= (1f / frameCountHit))
            {
                // 播放下一帧
                int index = ((int)(timerHit / (1f / frameCountHit))) % hitSprites.Length;
                if (index <= hitSprites.Length - 1)
                {
                    this.GetComponent<SpriteRenderer>().sprite = hitSprites[index];
                }
            }
        }
    }
    // 处理死亡的动画
    private void action_dead()
    {
        if (isDeaded)
        {
            // 播放动画
            timer += Time.deltaTime;

            // 播放下一帧
            int index = ((int)(timer / (1f / frameCount))) % explosionSprites.Length;
            this.GetComponent<SpriteRenderer>().sprite = explosionSprites[index];
            print(index);
            if (index >= explosionSprites.Length - 1)
            {
                // 销毁
                Destroy(this.gameObject);

            }

        }
    }

    // 处理被击中时候的事件
    public void BeHit()
    {
		if(isDeaded){
			return;
		}

        hp -= 1;
        if (hp <= 0)
        {
            isDeaded = true;
            isHited = false;
			// 加分
			gameManager.score+=score;
            // 播放声音
            explosionAudio.Play();
        }
        else
        {
            isHited = true;
        }


    }
}
