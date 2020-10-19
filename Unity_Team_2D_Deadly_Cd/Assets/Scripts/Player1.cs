using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using Spine.Unity;

public class Player1 : MonoBehaviour
{
    #region 屬性

    private bool isGround;   //地板的
    private bool isGround2;  //牆壁的
    private float timeout;   //牆壁延遲時間

    private Rigidbody2D rigi;

    [Range(0, 500)]
    public float jump;
    [Range(0, 500)]
    public float Move;
    public static int p1passfrequency;    //勝利次數

    public GameManagement m_gamemanagement;
    public SkeletonAnimation skeletonAnimation;

    /// <summary>
    /// 儲存設計面板上顯示的線條
    /// </summary>
    private RaycastHit2D[] rhit = new RaycastHit2D[5];
    /// <summary>
    /// 線條碰撞體得距離設定
    /// </summary>
    private Vector3[] raycast = { new Vector3(0, 0.1f), new Vector3(0.3f, 0.22f), new Vector3(-0.3f, 0.15f),
                                  new Vector3(-0.6f, 0.8f), new Vector3(0.5f, 0.8f)};
    private Gizmos[] Ghit = new Gizmos[5];

    #endregion

    #region 方法
    ///<summary>
    ///跳躍
    ///</summary>
    public void PlayerJump()
    {
        // 2射線碰撞物體 2D物理.射線碰撞(起點, 方向 "," 長度, 圖層(比Tag多"物理"判定))
        RaycastHit();
        bool playerjump = Input.GetKeyDown(KeyCode.W);
        //判斷有無碰到底下地板，有:等待   沒有:跳躍中
        if (rhit[0] || rhit[1] || rhit[2])
        {
            isGround = true;
            skeletonAnimation.AnimationName = "Idle";
        }
        else
            isGround = false;

        if (isGround)
        {
            if (playerjump)
            {
                skeletonAnimation.AnimationName = "jump";   //上面引用，更改spine的動畫名稱
                rigi.AddForce(new Vector2(0, jump));
                m_gamemanagement.m_audioSource.PlayOneShot(m_gamemanagement.jumpclip);
            }
        }
        //判斷有無碰到直的牆壁，有:可跳躍   沒有:等待0.3秒後才可跳躍
        else if (rhit[3] || rhit[4])
        {
            isGround2 = false;                                  //碰到牆壁時先取消跳躍並延遲時間
            if (!isGround2)
            {
                timeout += Time.deltaTime;
                if (timeout >= 0.3f)    isGround2 = true;
            }

            if (isGround2)
            {
                if (playerjump)
                {
                    skeletonAnimation.AnimationName = "jump";
                    rigi.AddForce(new Vector2(0, jump));
                    timeout = 0;
                }
            }

        }
    }
    /// <summary>
    /// 跳躍碰撞判斷
    /// </summary>
    public void RaycastHit()
    {
        for (int i = 0; i < rhit.Length; i++)
        {
            Vector3 trans = i < 3 ? -transform.up : i == 3 ? -transform.right : transform.right;//三元運算? true: i==3 ?  true : false;
            rhit[i] = Physics2D.Raycast(transform.position + raycast[i], trans, 0.1f, 1 << 8);
        }

    }
    /// <summary>
    /// 畫線
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        // 2射線碰撞物體 2D物理.射線碰撞(起點, 方向"*"長度)
        Gizmos.DrawRay(transform.position + new Vector3(0, 0.1f), -transform.up * 0.1f);
        Gizmos.DrawRay(transform.position + new Vector3(0.3f, 0.22f), -transform.up * 0.1f);
        Gizmos.DrawRay(transform.position + new Vector3(-0.3f, 0.15f), -transform.up * 0.1f);
        Gizmos.DrawRay(transform.position + new Vector3(-0.6f, 0.8f), -transform.right * 0.1f);
        Gizmos.DrawRay(transform.position + new Vector3(0.5f, 0.8f), transform.right * 0.1f);
    }
    #region 移動

    /// <summary>移動</summary>
    public void PlayMove()
    {
        bool playeLeftMove = Input.GetKey(KeyCode.A);
        bool playerRightMove = Input.GetKey(KeyCode.D);

        if (playerRightMove)
        {
            rigi.AddForce(new Vector2(Move, 0));
            skeletonAnimation.AnimationName = "Run";
        }
        if (playeLeftMove)
        {
            rigi.AddForce(new Vector2(-Move, 0));
            skeletonAnimation.AnimationName = "Run";
        }
    }

    public void AniWinSet()
    {
        if(skeletonAnimation.AnimationName == "win") return;
    }
    #endregion

    #endregion

    #region 事件

    private void Update()
    {
        PlayerJump();
        PlayMove();
    }

    private void Awake()
    {
        rigi = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "過關區域")
        {
            skeletonAnimation.loop = false;
            skeletonAnimation.AnimationName = "win";
            p1passfrequency++;
            m_gamemanagement.Pass(ref GameManagement.p1point, m_gamemanagement.p1pointMax, m_gamemanagement.player1bar);
        }
        if (collision.name =="死亡區域")
        {
            skeletonAnimation.AnimationName = "die";
        }
    }


    #endregion
}