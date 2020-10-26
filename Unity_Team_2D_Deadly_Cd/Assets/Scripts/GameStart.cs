using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public GameObject startbg;
    public GameObject characterbg;
    public GameObject checkpointbg;
    public GameObject player1GO;
    public GameObject player2GO;

    public RawImage treeRawImage;
    public RawImage flowerRawImage;
    public Texture treeTexture;
    public Texture flowerTexture;
    public bool player1CheckBool;
    public bool player2CheckBool;

    private void ProlongStart()
    {
        if (player1CheckBool && player2CheckBool)
        {
            Invoke("MainGameStart", 1f);
            
        }
    }
    public void ProlongExit()
    {
        Invoke("Exit", 1f);
    }
    private void MainGameStart()
    {
        SceneManager.LoadScene("遊戲場景");
    }

    private void Exit()
    {
        Application.Quit();
    }

    public void Checkpoint()
    {
        startbg.SetActive(false);
        characterbg.SetActive(true);
    }
    private void Change()
    {
        if (!player2CheckBool)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                flowerRawImage.texture = flowerTexture;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                flowerRawImage.texture = treeTexture;
            }
        }
        if (!player1CheckBool)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                treeRawImage.texture = treeTexture;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                treeRawImage.texture = flowerTexture;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player1CheckBool = true;
            player1GO.SetActive(true);
            
        }
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            player2CheckBool = true;
            player2GO.SetActive(true);
            
        }
    }


    private void Update()
    {
        ProlongStart();
        Change();
    }
}
