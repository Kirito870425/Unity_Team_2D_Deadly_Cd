using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManagement : MonoBehaviour
{
    #region 欄位

    public GameObject passimage;
    public GameObject nextgameimage;
    public Text clock;
    [Header("吧條區")]
    public Image player1bar;
    public Image player2bar;
    public static float p1point;
    public static float p2point;
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

    public void Pass(float point, float max, Image bar)
    {
        PlayerStop();
        passimage.SetActive(true);
        point++;
        bar.fillAmount = point / max;
    }

    public void Dead()
    {
        PlayerStop();
    }
    
    public void Next()
    {
        nextgameimage.SetActive(true);
    }
    public void PlayerStop()
    {
        player1Script.enabled = false;
        player2Script.enabled = false;
    }
    public void Reloding()
    {
        nextgameimage.SetActive(false);
        passimage.SetActive(false);
        SceneManager.LoadScene("遊戲場景");
    }
    public void Back()
    {
        nextgameimage.SetActive(false);
        passimage.SetActive(false);
        SceneManager.LoadScene("選單");
    }

    #endregion
}
