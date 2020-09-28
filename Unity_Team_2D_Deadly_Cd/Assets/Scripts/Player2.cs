using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player2 : MonoBehaviour
{
    #region 屬性
   
    public Rigidbody2D rigi;
    [Range(0, 500)]
    public float jump;
    [Range(0, 500)]
    public float Move;
    public int passfrequency;

    public bool isGround;
    public int[] hit;

    #endregion

    #region 方法
    public void PlayerJump()
    {
        // 2射線碰撞物體 2D物理.射線碰撞(起點, 方向 "," 長度, 圖層(比Tag多"物理"判定))
        RaycastHit2D hit1 = Physics2D.Raycast(transform.position + new Vector3(0, -0.5f), -transform.up, 0.1f, 1 << 8);
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position + new Vector3(0.3f, -0.5f), -transform.up, 0.1f, 1 << 8);
        RaycastHit2D hit3 = Physics2D.Raycast(transform.position + new Vector3(-0.3f, -0.5f), -transform.up, 0.1f, 1 << 8);
        RaycastHit2D hit4 = Physics2D.Raycast(transform.position + new Vector3(-0.5f, 0), -transform.right, 0.1f, 1 << 8);//左
        RaycastHit2D hit5 = Physics2D.Raycast(transform.position + new Vector3(0.5f, 0), transform.right, 0.1f, 1 << 8);//右

        bool playerjump = Input.GetKeyDown(KeyCode.UpArrow);


        if (hit1 || hit2 || hit3 || hit4 || hit5)
            isGround = true;
        else
            isGround = false;

        if (isGround)
        {
            if (playerjump)
            {
                rigi.AddForce(new Vector2(0, jump));
            }
        }
    }

    public void PlayMove()
    {
        bool playeLeftMove = Input.GetKey(KeyCode.LeftArrow);
        bool playerRightMove = Input.GetKey(KeyCode.RightArrow);

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

    #region 事件

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "過關區域")
        {
            passfrequency++;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        // 2射線碰撞物體 2D物理.射線碰撞(起點, 方向"*"長度)
        Gizmos.DrawRay(transform.position + new Vector3(0, 0.05f), -transform.up * 0.1f);
        Gizmos.DrawRay(transform.position + new Vector3(0.3f, 0.1f), -transform.up * 0.1f);
        Gizmos.DrawRay(transform.position + new Vector3(-0.3f, 0.1f), -transform.up * 0.1f);
        Gizmos.DrawRay(transform.position + new Vector3(-0.7f, 0.8f), -transform.right * 0.1f);
        Gizmos.DrawRay(transform.position + new Vector3(0.7f, 0.8f), transform.right * 0.1f);
    }

   

    private void Start()
    {

    }

    private void Update()
    {
        PlayerJump();
        PlayMove();
    }

    #endregion
}