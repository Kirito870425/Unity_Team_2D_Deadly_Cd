using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player1 : MonoBehaviour
{
    #region 屬性

    public Rigidbody2D rigi;
    [Range(0, 500)]
    public float jump;
    [Range(0, 500)]
    public float Move;
    public static int passfrequency;

    public bool isGround;
    public bool isGround2;
    public float timeout;
    public GameManagement m_gamemanagement;
    private RaycastHit2D[] rhit = new RaycastHit2D[5];
    private Vector3[] raycast = { new Vector3(0, -0.5f), new Vector3(0.3f, -0.5f), new Vector3(-0.3f, -0.5f),
                                  new Vector3(-0.5f, 0), new Vector3(0.5f, 0) };
    private Gizmos[] Ghit = new Gizmos[5];

    #endregion

    #region 方法

    #region 跳躍

    /// <summary>跳躍</summary>
    public void PlayerJump()
    {
        // 2射線碰撞物體 2D物理.射線碰撞(起點, 方向 "," 長度, 圖層(比Tag多"物理"判定))
        RaycastHit();
        bool playerjump = Input.GetKeyDown(KeyCode.W);

        if (rhit[0] || rhit[1] || rhit[2])
            isGround = true;
        else
            isGround = false;

        if (isGround)
        {
            if (playerjump)
            {
                rigi.AddForce(new Vector2(0, jump));
                m_gamemanagement.m_audioSource.PlayOneShot(m_gamemanagement.jumpclip);
            }
        }
        else if (rhit[3] || rhit[4])
        {
            isGround2 = false;                                  //碰到牆壁時先取消跳躍並延遲時間
            if (!isGround2)
            {
                timeout += Time.deltaTime;
                print(timeout);
                if (timeout >= 0.5f)
                {
                    isGround2 = true;
                }
            }

            if (isGround2)
            {
                if (playerjump)
                {
                    rigi.AddForce(new Vector2(0, jump));
                    timeout = 0;
                }
            }

        }
    }
    /// <summary>跳躍碰撞判斷</summary>
    public void RaycastHit()
    {
        for (int i = 0; i < rhit.Length; i++)
        {
            Vector3 trans = i < 3 ? -transform.up : i == 3 ? -transform.right : transform.right;//三元運算? true: i==3 ?  true : false;
            rhit[i] = Physics2D.Raycast(transform.position + raycast[i], trans, 0.1f, 1 << 8);
        }

    }

    #endregion
    #region 畫線

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        // 2射線碰撞物體 2D物理.射線碰撞(起點, 方向"*"長度)
        Gizmos.DrawRay(transform.position + new Vector3(0, -0.5f), -transform.up * 0.1f);
        Gizmos.DrawRay(transform.position + new Vector3(0.3f, -0.5f), -transform.up * 0.1f);
        Gizmos.DrawRay(transform.position + new Vector3(-0.3f, -0.5f), -transform.up * 0.1f);
        Gizmos.DrawRay(transform.position + new Vector3(-0.5f, 0), -transform.right * 0.1f);
        Gizmos.DrawRay(transform.position + new Vector3(0.5f, 0), transform.right * 0.1f);
    }

    #endregion

    #region 移動

    /// <summary>移動</summary>
    public void PlayMove()
    {
        bool playeLeftMove = Input.GetKey(KeyCode.A);
        bool playerRightMove = Input.GetKey(KeyCode.D);

        if (playerRightMove)
        {
            rigi.AddForce(new Vector2(Move, 0));
        }
        if (playeLeftMove)
        {
            rigi.AddForce(new Vector2(-Move, 0));
        }
    }
    #endregion

    #endregion

    #region 事件

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "過關區域")
        {
            passfrequency++;
        }

    }




    private void Update()
    {
        PlayerJump();
        PlayMove();
    }

    #endregion
}