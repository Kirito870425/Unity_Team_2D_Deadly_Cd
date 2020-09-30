using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManagement : MonoBehaviour
{
    #region 欄位

    public GameObject passimage;
    public GameObject victoryimage;
    public Text clock;
    [Header("吧條區")]
    public Image player1bar;
    public Image player2bar;
    public float p1point;
    public float p2point;
    public float p1pointMax = 10;
    public float p2pointMax = 10;
    [Header("音效區")]
    public AudioSource m_audioSource;
    public AudioClip jumpclip;
    public AudioClip jumpclip2;
    [Header("程式區")]
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
        PlayerStop();
    }

    public void Victory()
    {
        if (Player1.passfrequency >= 1)
        {
            PlayerStop();
            passimage.SetActive(true);
            p1point++;
            player1bar.fillAmount = p1point / p1pointMax;
        }
        else if (Player2.passfrequency >= 1)
        {
            PlayerStop();
            passimage.SetActive(true);
            p2point++;
            player2bar.fillAmount = p2point / p2pointMax;
        }
    }
    public void Next()
    {
        victoryimage.SetActive(true);
    }
    public void PlayerStop()
    {
        player1Script.enabled = false;
        player2Script.enabled = false;
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
