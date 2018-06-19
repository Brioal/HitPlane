using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    // 一帧播放几次
    private int framePerSecond = 10;
    // 计时器
    private float timer = 0;
    // 是否播放动画
    public bool animation = true;
    // 图片数组
    public Sprite[] spriters;
    // 是否手指按下了
    private bool isMouseDown = false;
    // 是否应该跟随手指
    private bool shouldFollow = false;
    // 子弹的时间
    public float bulletTime = 0;
    // 枪的数量
    private int gun_size = 1;
    // 左边的枪
    public GameObject gunLeft;
    // 右边的枪
    public GameObject gunRight;
    // 上边的枪
    public GameObject gunTop;
    // 获得奖励时候的声音
    public AudioSource awardSource;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 处理动画
        action_animation();
        // 手指动画
        action_move();
        // 处理奖励的动画
        action_gun();
    }

    // 判断枪的蕾西
    private void action_gun()
    {
        if (gun_size == 2 && bulletTime > 0)
        {
            // 启动超级弹药
            gunLeft.SetActive(true);
            gunRight.SetActive(true);
            gunTop.SetActive(false);
            bulletTime -= Time.deltaTime;
            if (bulletTime <= 0)
            {
                bulletTime = 0;
                gun_size = 1;
            }
        }
        else
        {
            // 普通弹药
            gunLeft.SetActive(false);
            gunRight.SetActive(false);
            gunTop.SetActive(true);
        }
    }

    // 手指动画
    private void action_move()
    {
        if(GameManager._instance.gameState!=GameState.Running){
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            isMouseDown = true;
            shouldFollow = false;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
            shouldFollow = false;
        }
        if (isMouseDown && !shouldFollow)
        {
            // 判断当前位置跟飞机位置是否差不多
            float offsetX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - this.transform.position.x;
            float offsetY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - this.transform.position.y;
            if (offsetX <= 0.4f && offsetY <= 0.4f)
            {
                shouldFollow = true;
            }

        }
        if (shouldFollow)
        {
            // 计算不超出屏幕的坐标
            float resultX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            if (resultX < -1.88f)
            {
                resultX = -1.88f;
            }
            if (resultX > 1.88f)
            {
                resultX = 1.88f;
            }
            float resultY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
            if (resultY < -3.65f)
            {
                resultY = -3.65f;
            }
            if (resultY > 3.5f)
            {
                resultY = 3.5f;
            }
            this.transform.position = new Vector3(resultX, resultY, this.transform.position.z);
        }
    }

    // 处理动画
    private void action_animation()
    {
        if (!animation)
        {
            return;
        }
        timer += Time.deltaTime;
        if (timer < 1.0f / framePerSecond)
        {
            return;
        }
        // 判断播放到了第几帧
        float frameTime = 1.0f / framePerSecond;
        int frameCount = (int)(timer / frameTime);
        // 确定显示第几帧
        int index = frameCount % spriters.Length;
        // 设置显示的图片
        this.GetComponent<SpriteRenderer>().sprite = spriters[index];
    }

    // 碰撞检测
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Award")
        {
            // 奖励物品
            deal_award(other);
            return;
        }
        if (other.tag == "Enemy")
        {
            // 敌人
        }
    }

    // 检测奖励
    private void deal_award(Collider2D other)
    {
        AwardType type = other.GetComponent<Award>().type;
        if (type == AwardType.AuardBullet)
        {
            // 子弹
            // 修改枪的类型
            gun_size = 2;
            // 修改时间
            bulletTime += Award.BULLET_TIME;
            // 销毁子弹
            Destroy(other.gameObject);
            // 播放声音
            awardSource.Play();
        }
    }
}
