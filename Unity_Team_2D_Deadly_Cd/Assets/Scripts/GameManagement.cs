using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManagement : MonoBehaviour
{
    #region 欄位

    public GameObject passimage;
    public GameObject victoryimage;
    public Text clock;
    public Image player1point;
    public Image player2point;

    public AudioSource m_audioSource;
    public AudioClip jumpclip;
    public AudioClip jumpclip2;

    public Player1 player1Script;
    public Player2 player2Script;

    #endregion

    #region 方法

    public void Pass()
    {
        //print("過關");
        //記分板，勝利動畫
        //passfrequency++;
    }

    public void Dead()
    {
        //print("死亡");
        PlayerStop();
    }

    public void Victory()
    {
        if (Player1.passfrequency >=1)
        {
            PlayerStop();
            passimage.SetActive(true);
        }
        else if (Player1.passfrequency < 1)
        {
            player1point.fillAmount = 0.1f;
        }
    }
    public void Next()
    {
        /*float point = player1point.fillAmount;
        if (point == 1)
        {
        }*/
            victoryimage.SetActive(true);
    }
    public void PlayerStop()
    {
        player1Script.jump = 0;
        player1Script.Move = 0;
    }
    public void Reloding()
    {
        SceneManager.LoadScene("遊戲場景");
    }
    public void Back()
    {
        SceneManager.LoadScene("選單");
    }

    #endregion

    #region 事件

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "過關區域")
            Pass();
        if (collision.name == "死亡區域")
            Dead();
    }
    private void Update()
    {
        //clock.text += Time.deltaTime;
        //print(clock.text);
        Victory();
    }

    #endregion
}
