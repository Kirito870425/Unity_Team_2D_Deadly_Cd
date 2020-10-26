using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManagement : MonoBehaviour
{
    #region 欄位
    [Header("計分板")]
    public GameObject passimage = null;
    [Header("結束畫面")]
    public GameObject nextgameimage = null;
    [Header("吧條區")]
    public Text clock;
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

    private Player1 _player1Script = null;
    private Player2 _player2Script = null;
    private GameStart _gameStart = null;

    #endregion

    #region 方法
    /// <summary>
    /// 計算過關分數
    /// </summary>
    /// <param name="point">分數</param>
    /// <param name="max">總分</param>
    /// <param name="bar">吧條</param>
    public void Pass(ref float point, float max, Image bar)
    {
        point++;
        bar.fillAmount = point / max;
        if (point >= max)
        {
            point = 0;
            nextgameimage.SetActive(true);
            passimage.SetActive(false);
        }
    }
    
    public void ExtendReloding()
    {
        Invoke("Reloding", 0.5f);
    }
    public void ExtendBack()
    {
        Invoke("Back", 0.5f);
    }
    private void Reloding()
    {
        nextgameimage.SetActive(false);
        passimage.SetActive(false);
        SceneManager.LoadScene("遊戲場景");
    }
    private void Back()
    {
        nextgameimage.SetActive(false);
        passimage.SetActive(false);
        SceneManager.LoadScene("選單");
    }
    private void WaitingForClearance()
    {
        if (_player1Script.passbool && _player2Script.passbool ||
            _player1Script.deadbool && _player2Script.deadbool ||
            _player1Script.passbool && _player2Script.deadbool ||
            _player1Script.deadbool && _player2Script.passbool)
        {
            passimage.SetActive(true);
        }
    }
    #endregion
    private void Awake()
    {
        _player1Script = FindObjectOfType<Player1>();
        _player2Script = FindObjectOfType<Player2>();
        _gameStart = FindObjectOfType<GameStart>();
        Destroy(_gameStart);
    }
    private void Update()
    {
        WaitingForClearance();
    }
}
