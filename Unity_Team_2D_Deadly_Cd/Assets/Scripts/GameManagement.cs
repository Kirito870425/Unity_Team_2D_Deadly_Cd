using UnityEngine;
using UnityEngine.UI;


public class GameManagement : MonoBehaviour
{
    #region 欄位

    public GameObject passimage;
    public Text clock,victorytext;

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
        print("死亡");
    }

    public void Victory()
    {
        if (player1Script.passfrequency >=5)
        {
            passimage.SetActive(true);
            victorytext.text = "玩家一贏了";
        }
        else if (player2Script.passfrequency >=5)
        {
            passimage.SetActive(true);
            victorytext.text = "玩家二贏了";
        }
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
